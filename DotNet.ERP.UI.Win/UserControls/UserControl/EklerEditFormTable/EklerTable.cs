using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.UI.Win.GenelForms;
using DotNet.ERP.UI.Win.UserControls.UserControl.Base;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.UserControls.UserControl.EklerEditFormTable
{
    public partial class EklerTable : BaseTablo
    {
        #region Variables
        private readonly KayitTuru _kayitTuru;
        private readonly long _kayitId;
        private const long MaxFileSize = 25 * 1024 * 1024; // 25 MB        
        private static readonly string[] AllowedExtensions =
        {
            "pdf",
            "jpg",
            "jpeg",
            "png",
            "xlsx",
            "docx",
            "rtf",
            "txt"
        };        
        private static string _cachedKokDizin = null;
        private bool _geciciKayitVar;
        #endregion
        public EklerTable(KayitTuru kayitTuru, long kayitId)
        {
            InitializeComponent();
            Bll = new EklerBll();
            Tablo = tablo;
            tablo.CustomColumnDisplayText += tablo_CustomColumnDisplayText;
            _kayitTuru = kayitTuru;
            _kayitId = kayitId;
            EventsLoad();

            btnHareketEkle.Caption = "Ekle";
            btnHareketSil.Caption = "Sil";
            btnDuzelt.Caption = "Dosyayı Değiştir";
            ButonlariAyarla();
            tablo.FocusedRowChanged += (s, e) =>
            {
                ButonlariAyarla();
                ButonEnabledDurumu(tablo.DataRowCount > 0 && tablo.FocusedRowHandle >= 0);
            };

            tablo.RowCellClick += (s, e) =>
            {
                if (e.Clicks == 2 && e.RowHandle >= 0)
                    DosyaAc();
            };
            tablo.FocusedRowChanged += (s, e) => ButonlariGuncelle();
        }
        private void ButonlariAyarla()
        {
            bool kayitVar = tablo.DataRowCount > 0;

            if (!kayitVar)
            {
                // HİÇ KAYIT YOK
                ShowItems = new BarItem[]
                {
                    btnHareketEkle
                };

                HideItems = new BarItem[]
                {
                    btnHareketSil,
                    btnDuzelt,
                    btnIndir,
                    btnAc
                };
            }
            else
            {
                // KAYIT VAR
                ShowItems = new BarItem[]
                {
                    btnHareketEkle,
                    btnHareketSil,
                    btnDuzelt,
                    btnIndir,
                    btnAc
                };

                HideItems = Array.Empty<BarItem>();
            }
        }
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
        protected internal override void Listele()
        {
            if (_geciciKayitVar)
                return;
            tablo.GridControl.DataSource = ((EklerBll)Bll).List(x => x.KayitTuru == _kayitTuru && x.KayitId == _kayitId).ToBindingList<EklerL>();
            ButonEnabledDurumu(tablo.DataRowCount > 0);
            ButonlariGuncelle();
        }      
        protected override void HareketEkle()
        {
            if (!KokDizinKontroluYap())
                return;
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "İzinli Dosyalar|*.pdf;*.jpg;*.jpeg;*.png;*.xlsx;*.docx;*.rtf;*.txt";
                dialog.Title = "Dosya Seç";
                dialog.Multiselect = false;
                dialog.InitialDirectory =
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                FileInfo fileInfo;
                try
                {
                    fileInfo = new FileInfo(dialog.FileName);
                }
                catch
                {
                    Messages.DosyaYoluHatali();
                    return;
                }

                string ext = fileInfo.Extension.TrimStart('.').ToLowerInvariant();

                //if (!AllowedExtensions.Contains(ext))
                //{
                //    Messages.UyariMesaji("Bu dosya türüne izin verilmiyor.");
                //    return;
                //}
                if (!AllowedExtensions.Any(x => x.Equals(ext, StringComparison.OrdinalIgnoreCase)))
                {
                    Messages.UyariMesaji("Bu dosya türüne izin verilmiyor.");
                    return;
                }
                if (fileInfo.Length == 0 || fileInfo.Length > MaxFileSize)
                {
                    Messages.UyariMesaji("Dosya boyutu geçersiz.");
                    return;
                }

                string tempKlasor;
                string tempDosyaYolu;

                try
                {
                    tempKlasor = Path.Combine(Path.GetTempPath(), "ERP_EKLER");
                    Directory.CreateDirectory(tempKlasor);

                    tempDosyaYolu = Path.Combine(
                        tempKlasor,
                         $"{Guid.NewGuid()}.{ext}");

                    File.Copy(fileInfo.FullName, tempDosyaYolu, true);
                }
                catch (UnauthorizedAccessException)
                {
                    Messages.DosyaYetkisizErisim();
                    return;
                }
                catch (IOException)
                {
                    Messages.DosyaKilitli();
                    return;
                }
                catch (Exception ex)
                {
                    Messages.BeklenmeyenHata(ex.Message);
                    return;
                }

                var entity = new EklerL
                {
                    KayitTuru = _kayitTuru,
                    KayitId = _kayitId,
                    Insert = true,
                    EklemeTarihi = DateTime.Now,
                    DosyaAdi = fileInfo.Name,
                    DosyaUzantisi = ext,
                    DosyaBoyutu = fileInfo.Length,
                    EkleyenKullaniciId = AnaForm.KullaniciId,
                    YeniDosyaTempYolu = tempDosyaYolu
                };
                _geciciKayitVar = true;
                tablo.DataController.ListSource.Add(entity);
                tablo.RefleshDataSource();
                tablo.FocusedRowHandle = tablo.DataRowCount - 1;
                tablo.FocusedColumn = colBaslik;
                ButonEnabledDurumu(true);
            }
        }   
        protected override void DosyaDuzelt()
        {
            if (!KokDizinKontroluYap())
                return;
            var entity = tablo.GetFocusedRow() as EklerL;
            if (entity == null)
                return;

            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "İzinli Dosyalar|*.pdf;*.jpg;*.jpeg;*.png;*.xlsx;*.docx;*.rtf;*.txt";
                dialog.Title = "Yeni Dosya Seç";
                dialog.Multiselect = false;

                // 🔥 Önce temp, yoksa fiziksel yol
                if (!string.IsNullOrEmpty(entity.YeniDosyaTempYolu))
                {
                    dialog.InitialDirectory =
                        Path.GetDirectoryName(entity.YeniDosyaTempYolu);
                }
                else if (!string.IsNullOrEmpty(entity.DosyaYolu))
                {
                    try
                    {
                        var kokDizin = _cachedKokDizin
                            ?? (_cachedKokDizin = new EklerDepolamaAyarlariBll().GetKokDizin());

                        if (!string.IsNullOrEmpty(kokDizin))
                        {
                            dialog.InitialDirectory =
                                Path.GetDirectoryName(Path.Combine(kokDizin, entity.DosyaYolu));
                        }
                    }
                    catch
                    {
                        // sessiz geçiyoruz, dialog yine açılır
                    }
                }

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                FileInfo yeniDosya;
                try
                {
                    yeniDosya = new FileInfo(dialog.FileName);
                }
                catch
                {
                    Messages.DosyaYoluHatali();
                    return;
                }

                // 🔥 uzantıyı NOKTASIZ al
                string ext = yeniDosya.Extension
                    .TrimStart('.')
                    .ToLowerInvariant();

                if (!AllowedExtensions.Contains(ext))
                {
                    Messages.UyariMesaji("Bu dosya türüne izin verilmiyor.");
                    return;
                }

                if (yeniDosya.Length == 0 || yeniDosya.Length > MaxFileSize)
                {
                    Messages.UyariMesaji("Dosya boyutu geçersiz.");
                    return;
                }

                // 🔥 Eski temp dosyayı temizle
                if (!string.IsNullOrEmpty(entity.YeniDosyaTempYolu) &&
                    File.Exists(entity.YeniDosyaTempYolu))
                {
                    try
                    {
                        File.Delete(entity.YeniDosyaTempYolu);
                    }
                    catch
                    {
                        // kritik değil, devam edebilir
                    }
                }

                string tempKlasor;
                string tempYol;

                try
                {
                    tempKlasor = Path.Combine(Path.GetTempPath(), "ERP_EKLER");
                    Directory.CreateDirectory(tempKlasor);

                    tempYol = Path.Combine(
                        tempKlasor,
                        $"{Guid.NewGuid()}.{ext}");

                    File.Copy(yeniDosya.FullName, tempYol, true);
                }
                catch (UnauthorizedAccessException)
                {
                    Messages.DosyaYetkisizErisim();
                    return;
                }
                catch (IOException)
                {
                    Messages.DosyaKilitli();
                    return;
                }
                catch (Exception ex)
                {
                    Messages.DosyaAcilamadi(ex.Message);
                    return;
                }

                // 🔁 ENTITY GÜNCELLE
                entity.YeniDosyaTempYolu = tempYol;
                entity.DosyaAdi = yeniDosya.Name;
                entity.DosyaUzantisi = ext;          // 🔥 noktasız
                entity.DosyaBoyutu = yeniDosya.Length;
                entity.EklemeTarihi = DateTime.Now;
                entity.EkleyenKullaniciId = AnaForm.KullaniciId;

                entity.Update = true;
                entity.Insert = false;

                tablo.RefleshDataSource();
                ButonEnabledDurumu(true);
            }
        }
        protected override void HareketSil()
        {
            var entity = tablo.GetFocusedRow() as EklerL;
            if (entity == null)
                return;

            if (Messages.DosyaSilMesaji() != DialogResult.Yes)
                return;

            // 🔥 YENİ EKLENMİŞ ama HENÜZ KAYDEDİLMEMİŞ dosya
            if (entity.Id == 0)
            {
                // varsa temp dosyayı sil
                if (!string.IsNullOrEmpty(entity.YeniDosyaTempYolu) &&
                    File.Exists(entity.YeniDosyaTempYolu))
                {
                    try
                    {
                        File.Delete(entity.YeniDosyaTempYolu);
                    }
                    catch { /* kritik değil */ }
                }

                // listeden tamamen çıkar
                var list = Tablo.DataController.ListSource as IList<EklerL>;
                list?.Remove(entity);

                Tablo.RefleshDataSource();
                ButonEnabledDurumu(tablo.DataRowCount > 0);
                return;
            }

            // 🔥 SADECE DB'de var olanlar DELETE olur
            entity.Delete = true;
            entity.Insert = false;
            entity.Update = false;

            Tablo.RefleshDataSource();
            ButonEnabledDurumu(tablo.DataRowCount > 0);
        }
        protected override void DosyaAc()
        {
            var entity = tablo.GetFocusedRow() as EklerL;
            if (entity == null)
                return;

            string fizikselYol = null;

            // =====================================================
            // 1️⃣ KAYDEDİLMEMİŞ (GEÇİCİ) SATIR → SADECE TEMP DOSYA
            // =====================================================
            if (entity.Id == 0)
            {
                if (string.IsNullOrEmpty(entity.YeniDosyaTempYolu) ||
                    !File.Exists(entity.YeniDosyaTempYolu))
                {
                    Messages.FizikselDosyaBulunamadi();
                    return;
                }

                fizikselYol = entity.YeniDosyaTempYolu;
            }
            // =====================================================
            // 2️⃣ KAYDEDİLMİŞ SATIR → KÖK DİZİN
            // =====================================================
            else
            {
                string kokDizin;
                try
                {
                    kokDizin = _cachedKokDizin
                        ?? (_cachedKokDizin = new EklerDepolamaAyarlariBll().GetKokDizin());
                }
                catch
                {
                    Messages.KokDizinErisilemiyor();
                    return;
                }

                if (string.IsNullOrEmpty(kokDizin))
                {
                    Messages.KokDizinBulunamadi();
                    return;
                }

                if (string.IsNullOrEmpty(entity.DosyaYolu))
                {
                    Messages.FizikselDosyaBulunamadi();
                    return;
                }

                try
                {
                    fizikselYol = Path.Combine(kokDizin, entity.DosyaYolu);
                }
                catch
                {
                    Messages.DosyaYoluHatali();
                    return;
                }

                if (!File.Exists(fizikselYol))
                {
                    Messages.FizikselDosyaBulunamadi();
                    return;
                }
            }

            // =====================================================
            // 3️⃣ AÇMAK İÇİN TEMP KOPYA OLUŞTUR
            // =====================================================
            string tempDosya;
            try
            {
                tempDosya = Path.Combine(
                    Path.GetTempPath(),
                    Guid.NewGuid() + Path.GetExtension(fizikselYol));

                File.Copy(fizikselYol, tempDosya, true);
            }
            catch
            {
                Messages.DosyaAcilamadi();
                return;
            }

            // =====================================================
            // 4️⃣ DOSYAYI AÇ
            // =====================================================
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = tempDosya,
                    UseShellExecute = true
                });
            }
            catch
            {
                Messages.DosyaAcilamadi();
            }
        }
        protected override void DosyaIndir()
        {
            var entity = tablo.GetFocusedRow() as EklerL;
            if (entity == null)
                return;

            string kokDizin;
            try
            {
                kokDizin = _cachedKokDizin
                    ?? (_cachedKokDizin = new EklerDepolamaAyarlariBll().GetKokDizin());
            }
            catch
            {
                Messages.KokDizinErisilemiyor();
                return;
            }

            if (string.IsNullOrEmpty(kokDizin))
            {
                Messages.KokDizinBulunamadi();
                return;
            }

            string kaynakDosya;
            try
            {
                kaynakDosya = Path.Combine(kokDizin, entity.DosyaYolu);
            }
            catch (ArgumentException)
            {
                Messages.DosyaYoluHatali();
                return;
            }

            if (!File.Exists(kaynakDosya))
            {
                Messages.FizikselDosyaBulunamadi();
                return;
            }

            using (var dialog = new SaveFileDialog())
            {
                dialog.Title = "Dosyayı Kaydet";
                dialog.FileName = entity.DosyaAdi;
                dialog.Filter = "Tüm Dosyalar|*.*";
                dialog.InitialDirectory =
                    Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    File.Copy(kaynakDosya, dialog.FileName, true);
                    // Bilgi mesajı istersen buraya eklenebilir
                    // Messages.BilgiMesaji("Dosya başarıyla indirildi.");
                }
                catch (UnauthorizedAccessException)
                {
                    Messages.DosyaYetkisizErisim();
                }
                catch (IOException)
                {
                    Messages.DosyaKilitli();
                }
                catch (Exception ex)
                {
                    Messages.BeklenmeyenHata(ex.Message);
                }
            }
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
        protected override void Tablo_RowCountChanged(object sender, EventArgs e)
        {
            base.Tablo_RowCountChanged(sender, e);
            ButonlariGuncelle();
        }
        protected override void Tablo_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            var entity = tablo.GetFocusedRow() as EklerL;
            if (entity == null)
                return;

            // 🔥 GEÇİCİ KAYIT → GRID REFRESH YOK
            if (entity.Id == 0)
            {
                // Grid zaten entity'yi güncelledi
                // Refresh, reload, base çağrısı YASAK
                return;
            }

            // 🔹 DB KAYDI
            entity.Update = true;
            entity.Insert = false;

            base.Tablo_CellValueChanged(sender, e);
        }
        protected override void Tablo_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            base.Tablo_FocusedColumnChanged(sender, e);

            if (e.FocusedColumn == colBelgeAdi)
                e.FocusedColumn.Sec(tablo, insUptNavigator.Navigator, repositoryBelge, colBelgeTuruId);
        }
        private bool KokDizinKontroluYap()
        {
            string kokDizin;

            try
            {
                kokDizin = _cachedKokDizin
                    ?? (_cachedKokDizin = new EklerDepolamaAyarlariBll().GetKokDizin());
            }
            catch
            {
                Messages.KokDizinErisilemiyor();
                return false;
            }

            if (string.IsNullOrWhiteSpace(kokDizin))
            {
                Messages.UyariMesaji(
                    "Ekler için depolama dizini tanımlanmamış.\n\n" +
                    "Lütfen Yönetim → Ekler Depolama Ayarları bölümünden dizin atayınız."
                );
                return false;
            }

            if (!Directory.Exists(kokDizin))
            {
                Messages.UyariMesaji(
                    "Ekler için tanımlanan dizin fiziksel olarak bulunamadı.\n\n" +
                    $"Dizin: {kokDizin}\n\n" +
                    "Lütfen Yönetim → Ekler Depolama Ayarları bölümünü kontrol ediniz."
                );
                return false;
            }

            return true;
        }
        private void ButonlariGuncelle()
        {
            var entity = tablo.GetFocusedRow() as EklerL;

            // Her zaman açık
            btnHareketEkle.Enabled = true;

            // Seçili satır yoksa
            if (entity == null)
            {
                btnHareketSil.Enabled = false;
                btnDuzelt.Enabled = false;
                btnAc.Enabled = false;
                btnIndir.Enabled = false;
                return;
            }

            // 🔥 Henüz DB’ye gitmemiş kayıt
            if (entity.Id == 0)
            {
                btnHareketSil.Enabled = true;   // listeden silinebilir
                btnDuzelt.Enabled = false;               
                btnIndir.Enabled = false;
                btnAc.Enabled = !string.IsNullOrEmpty(entity.YeniDosyaTempYolu) && File.Exists(entity.YeniDosyaTempYolu);
                return;
            }

            // 🔥 DB'de var olan kayıt
            btnHareketSil.Enabled = true;
            btnDuzelt.Enabled = true;
            btnAc.Enabled = true;
            btnIndir.Enabled = true;
        }
        protected override void KaydetSonrasi()
        {
            GeciciKayitTemizle();     
        }
        public void GeciciKayitTemizle()
        {
            _geciciKayitVar = false;      
        }
        public override void GeriAl()
        {
            // Geçici eklenmiş ama kaydedilmemiş satırları temizle
            var source = Tablo.DataController.ListSource as IList<EklerL>;
            if (source == null) return;

            for (int i = source.Count - 1; i >= 0; i--)
            {
                if (source[i].Insert)
                {
                    // Eğer dosya yolu varsa ve gerçekten geçiciyse
                    if (!string.IsNullOrEmpty(source[i].DosyaYolu) &&
                        File.Exists(source[i].DosyaYolu))
                    {
                        try { File.Delete(source[i].DosyaYolu); }
                        catch { /* loglanabilir */ }
                    }

                    source.RemoveAt(i);
                }
            }

            Tablo.RefreshData();
        }
    }
}