using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.UI.Win.GenelForms;
using DotNet.ERP.UI.Win.UserControls.UserControl.Base;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.UserControls.UserControl.PersonelEditFormTable
{
    public partial class PersonelEklerTable : BaseTablo
    {
        private readonly KayitTuru _kayitTuru;
        private readonly long _kayitId;

        private const long MaxFileSize = 25 * 1024 * 1024; // 10 MB

        private static readonly string[] AllowedExtensions =
        {
            ".pdf",
            ".jpg",
            ".jpeg",
            ".png",
            ".xlsx",
            ".docx"
        };
        private string FormatFileSize(long bytes)
        {
            const long KB = 1024;
            const long MB = KB * 1024;
            const long GB = MB * 1024;

            if (bytes >= GB)
                return $"{bytes / (double)GB:0.##} GB";
            if (bytes >= MB)
                return $"{bytes / (double)MB:0.##} MB";
            if (bytes >= KB)
                return $"{bytes / (double)KB:0.##} KB";

            return $"{bytes} B";
        }
  

        public PersonelEklerTable(KayitTuru kayitTuru, long kayitId)
        {
            InitializeComponent();
            Bll = new EklerBll();
            Tablo = tablo;
            tablo.CustomColumnDisplayText += tablo_CustomColumnDisplayText;
            _kayitTuru = kayitTuru;
            _kayitId = kayitId;
            EventsLoad();
        }
        private void tablo_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == colDosyaBoyutu && e.Value != null)
            {
                if (long.TryParse(e.Value.ToString(), out long bytes))
                {
                    e.DisplayText = FormatFileSize(bytes);
                }
            }
        }
        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((EklerBll)Bll).List(x => x.KayitTuru == _kayitTuru && x.KayitId == _kayitId).ToBindingList<EklerL>();
        }        
        protected override void HareketEkle()
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "İzinli Dosyalar|*.pdf;*.jpg;*.jpeg;*.png;*.xlsx;*.docx";
                dialog.Title = "Dosya Seç";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                var fileInfo = new FileInfo(dialog.FileName);

                string fileExtension = fileInfo.Extension.ToLower();
                long fileSize = fileInfo.Length;

                if (fileSize == 0)
                {
                    MessageBox.Show("Seçilen dosya boş olamaz.");
                    return;
                }

                if (fileSize > MaxFileSize)
                {
                    MessageBox.Show($"Dosya boyutu {FormatFileSize(MaxFileSize)} sınırını aşamaz.");
                    return;
                }

                if (!AllowedExtensions.Contains(fileExtension))
                {
                    MessageBox.Show("Bu dosya türüne izin verilmiyor.");
                    return;
                }
              
                var kokDizin = new EklerDepolamaAyarlariBll().GetKokDizin();

                if (string.IsNullOrEmpty(kokDizin))
                {
                    MessageBox.Show("Ekler için kök dizin tanımlanmamış.");
                    return;
                }
                string ekKlasor = $"EK{(byte)_kayitTuru}";               
                string personelKlasor = Path.Combine(kokDizin, ekKlasor, _kayitId.ToString());

                if (!Directory.Exists(personelKlasor))
                    Directory.CreateDirectory(personelKlasor);
           
                string hedefYol = GetUniqueFilePath(personelKlasor, fileInfo.Name);                
                File.Copy(dialog.FileName, hedefYol);
                var source = tablo.DataController.ListSource;

                var row = new EklerL
                {
                    KayitTuru = _kayitTuru,
                    KayitId = _kayitId,
                    EklemeTarihi = DateTime.Now,
                    Insert = true,

                    DosyaAdi = fileInfo.Name,         
                    DosyaYolu = hedefYol,             
                    DosyaUzantisi = fileExtension,
                    DosyaBoyutu = fileSize,
                    EkleyenKullaniciId = AnaForm.KullaniciId
                };

                source.Add(row);

                tablo.RefleshDataSource();
                tablo.FocusedRowHandle = tablo.DataRowCount - 1;
                tablo.FocusedColumn = colBaslik;

                ButonEnabledDurumu(true);
            }
        }

        private string GetUniqueFilePath(string directory, string fileName)
        {
            string name = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);

            string fullPath = Path.Combine(directory, fileName);
            int count = 1;

            while (File.Exists(fullPath))
            {
                fullPath = Path.Combine(directory, $"{name} ({count}){extension}");
                count++;
            }

            return fullPath;
        }
        protected override void Tablo_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            base.Tablo_CellValueChanged(sender, e);
            var entity = tablo.GetRow<EklerL>();
        }
        protected override void Tablo_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            base.Tablo_FocusedColumnChanged(sender, e);
        }
    }
}
