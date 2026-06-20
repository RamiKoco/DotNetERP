using DotNet.ERP.Bll.General.CarilerBll;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Data.Contexts;
using DotNet.ERP.Model.Dto.CariDto;
using DotNet.ERP.Model.Entities.CariEntity;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Forms.CariForms.CarilerForms;
using DotNet.ERP.UI.Win.Forms.CariForms.CariSubeForms;
using DotNet.ERP.UI.Win.Forms.KisiForms;
using DotNet.ERP.UI.Win.UserControls.UserControl.Base;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.UserControls.UserControl.KisiEditFormTable
{
    public partial class CariKayitTuruBaglantiTable : BaseTablo
    {       
        public CariKayitTuruBaglantiTable()
        {
            InitializeComponent();

            Bll = new KisiKayitTuruBaglantiBll();
            Tablo = tablo;
            EventsLoad();
            TabloEventsYukle();        

            repositoryKayitTuru.Items.Clear();

            repositoryKayitTuru.Items.Add(new ImageComboBoxItem(
                KayitTuru.Cari.GetEnumDescription(), KayitTuru.Cari));

            repositoryKayitTuru.Items.Add(new ImageComboBoxItem(
                KayitTuru.CariSube.GetEnumDescription(), KayitTuru.CariSube));           

            repositoryKayitTuru.TextEditStyle = TextEditStyles.DisableTextEditor;

            btnBaglantiOzeti.ItemClick += (s, e) => CariIletisimKartAc();
            
            tablo.CellValueChanging += Tablo_CellValueChanging;
            tablo.ShownEditor += (s, e) =>
            {
                if (tablo.FocusedColumn == colKayitHesabi && tablo.ActiveEditor != null)
                {
                    var editor = tablo.ActiveEditor;
                    editor.KeyDown -= Editor_KeyDown;
                    editor.KeyDown += Editor_KeyDown;
                }
            };

            tablo.HiddenEditor += (s, e) =>
            {
                if (tablo.ActiveEditor != null)
                    tablo.ActiveEditor.KeyDown -= Editor_KeyDown;
            };
        }
        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((KisiKayitTuruBaglantiBll)Bll)
                .List(x => x.KisiId == OwnerForm.Id)
                .ToBindingList<KisiKayitTuruBaglantiL>();
        }
        protected override void HareketEkle()
        {    
            var currentKayitTuru = KayitTuru.Cari;
            if (currentKayitTuru == 0) return; 

            var source = tablo.DataController.ListSource;
            var row = new KisiKayitTuruBaglantiL
            {
                KisiId = OwnerForm.Id,
                Insert = true,
                KayitTuru = currentKayitTuru,
                KayitHesabi = string.Empty,
                AnaKayitHesabi = string.Empty,
                Kod=string.Empty
            };

            source.Add(row);
            tablo.Focus();
            tablo.RefleshDataSource();
            tablo.FocusedRowHandle = tablo.DataRowCount - 1;
            tablo.FocusedColumn = colKayitTuru;
            ButonEnabledDurumu(true);
        }
        protected override void Tablo_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            base.Tablo_CellValueChanged(sender, e);
   
            var entity = tablo.GetRow<KisiKayitTuruBaglantiL>();
            if (entity == null) return;

            var list = tablo.DataController.ListSource as IList<KisiKayitTuruBaglantiL>;
            if (list == null) return;
             
            if (e.Column == colKayitTuru)
            {
                entity.KayitId = 0;
                entity.KayitHesabi = null;
                entity.AnaKayitHesabi = null;
                entity.Kod = null;
                SutunGizleGoster();
                tablo.RefleshDataSource();
                return; 
            }
           
            if (e.Column == colKayitId && entity.KayitId != 0)
            {
                
                if (list.Any(x => x.KayitId == entity.KayitId && !ReferenceEquals(x, entity)))
                {
                    Messages.UyariMesaji("Bu kayıt zaten listede mevcut! Satır iptal edildi.");

                    tablo.CancelUpdateCurrentRow();

                    entity.KayitId = 0;
                    entity.KayitHesabi = null;
                    entity.AnaKayitHesabi = null;
                    entity.Kod = null;

                    tablo.RefleshDataSource();
                    return;
                }
                
                if (entity.KayitTuru == KayitTuru.Cari)
                {
                    using (var bll = new CariBll())
                    {
                        var cari = (Cari)bll.Single(x => x.Id == entity.KayitId);
                        if (cari != null)
                        {
                            entity.Kod = cari.Kod;
                            entity.KayitHesabi = cari.Unvan;
                        }
                    }
                }

                else if (entity.KayitTuru == KayitTuru.CariSube)
                {
                    using (var context = new ERPContext())
                    {
                        var sube = context.CariSube
                            .Include("Cari")                               // 🔥 string ile Include ediyoruz
                            .FirstOrDefault(c => c.Id == entity.KayitId);  // Artık cari null gelmez

                        if (sube != null)
                        {
                            entity.Kod = sube.Kod;
                            entity.KayitHesabi = sube.Ad;
                            entity.AnaKayitHesabi = sube.Cari?.Unvan;       // İlk seçimde bile doğru gelir
                        }
                    }

                    tablo.RefleshDataSource();
                }

                tablo.RefleshDataSource();
            }
        }
        protected override void Tablo_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            base.Tablo_FocusedColumnChanged(sender, e);

            if (e.FocusedColumn == colKayitHesabi)
                e.FocusedColumn.Sec(tablo, insUptNavigator.Navigator, repositoryCariler, colKayitId);

            if (e.FocusedColumn == colPozisyonAdi)
                e.FocusedColumn.Sec(tablo, insUptNavigator.Navigator, repositoryPozisyon, colPozisyonId);
        }
        private void RepositoryKayitTuru_Format(object sender, ConvertEditValueEventArgs e)
        {
            if (e.Value is KayitTuru kayitTuru)
                e.Value = kayitTuru.GetEnumDescription();
        }
        private void RepositoryKayitTuru_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (e.Value is string text)
            {
                if (text.Contains("Cari Şube"))
                    e.Value = KayitTuru.CariSube;
                else
                    e.Value = KayitTuru.Cari;
            }

        } 
        public bool KaydetKontrollu()
        {
            if (!(tablo.DataController.ListSource is IList<KisiKayitTuruBaglantiL> list) || !list.Any())
                return true;

            var invalidRows = list.Where(x =>
                x.KayitTuru != 0 &&
                (x.KayitId == 0 || string.IsNullOrWhiteSpace(x.KayitHesabi))
            ).ToList();

            if (invalidRows.Any())
            {
                string message = $"Toplam {invalidRows.Count} kayıt hatalı.\n" +
                                 "Kayıt türü değiştirilen ancak kaydı seçilmeyen satırlar kaydedilemez.";
                Messages.UyariMesaji(message);

                foreach (var row in invalidRows)
                {
                    int index = list.IndexOf(row);
                    if (index >= 0)
                        tablo.FocusedRowHandle = index;
                } 
                return false;
            }

            return this.Kaydet();
        }
        protected override void HareketSil()
        {
            if (Tablo.DataRowCount == 0) return;
            if (Messages.SilMesaj("İşlem Satırı") != DialogResult.Yes) return;

            var list = Tablo.DataController.ListSource as IList<KisiKayitTuruBaglantiL>;
            var row = Tablo.GetRow<KisiKayitTuruBaglantiL>();

            if (row != null)
            {
                if (row.KayitId == 0)
                {                    
                    list.Remove(row);
                }
                else
                {
                    row.Delete = true;
                }

                Tablo.RefleshDataSource();
                ButonEnabledDurumu(true);
            }
        }
        protected override void SutunGizleGoster()
        {
            if (tablo.DataRowCount == 0) return;
            var entity = tablo.GetRow<KisiKayitTuruBaglantiL>();
            if (entity == null) return;

            colAnaKayitHesabi.VisibleIndex = 3;
            colAnaKayitHesabi.Visible = entity.KayitTuru == KayitTuru.CariSube;

        }  
        private void Tablo_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column == colKayitTuru)
            {
                var entity = tablo.GetRow<KisiKayitTuruBaglantiL>();
                if (entity == null) return;
               
                entity.KayitId = 0;
                entity.KayitHesabi = string.Empty;
                entity.AnaKayitHesabi = string.Empty;
                entity.Kod = string.Empty;

                tablo.RefleshDataSource();
                ButonEnabledDurumu(false);
            }
        }
        private void Editor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.Delete)
            {
                var view = tablo;

                view.SetRowCellValue(view.FocusedRowHandle, colKayitHesabi, string.Empty);
                view.SetRowCellValue(view.FocusedRowHandle, colAnaKayitHesabi, string.Empty);
                view.SetRowCellValue(view.FocusedRowHandle, colKod, string.Empty);
                view.SetRowCellValue(view.FocusedRowHandle, colKayitId, 0);

                view.CloseEditor();      // editörü kapat
                view.UpdateCurrentRow(); // row'u güncelle

                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
        protected internal override bool HataliGiris()
        {
            bool hatali = false;

            if (tablo.HasColumnErrors) tablo.ClearColumnErrors();

            var list = tablo.DataController.ListSource as IList<KisiKayitTuruBaglantiL>;
            if (list == null || !list.Any()) return false;

            for (int i = 0; i < list.Count; i++)
            {
                var entity = list[i];
                if ((entity.Insert || entity.Update) &&
                    (entity.KayitId == 0 || string.IsNullOrWhiteSpace(entity.KayitHesabi)))
                {
                    tablo.FocusedRowHandle = i;
                    tablo.SetColumnError(colKayitHesabi, "Kayıt seçilmeli ve geçerli olmalı.");
                    hatali = true;
                }
            }

            if (hatali)
            {
                Messages.TabloEksikBilgiMesaji($"{tablo.ViewCaption}");
                return true; // <- çok önemli
            }

            return false;
        }       
        private void CariIletisimKartAc()
        {
            var entity = tablo.GetRow<KisiKayitTuruBaglantiL>();
            if (entity == null) { Messages.HataMesaji("Lütfen bir satır seçiniz."); return; }
            if (entity.KayitId == 0) { Messages.UyariMesaji("Bu satıra ait kayıt seçilmemiş."); return; }

            var kisiForm = OwnerForm as KisiEditForm;

            BaseEditForm frm = null;

            if (entity.KayitTuru == KayitTuru.Cari)
                frm = new CariBaglantiEditForm();
            else if (entity.KayitTuru == KayitTuru.CariSube)
                frm = new CariSubeBaglantiEditForm();
            else
                return;

            try
            {
                // 1) ÖNCE KİŞİ BİLGİSİNİ ATA  (EN ÖNEMLİ ADIM)
                if (kisiForm != null)
                {
                    frm.GetType().GetProperty("KisiId")?.SetValue(frm, kisiForm.KisiIdValue);
                    frm.GetType().GetProperty("KisiAdiSoyadi")?.SetValue(frm, kisiForm.KisiAdiSoyadi);
                }

                // 2) SONRA Id ve İşlem Türünü ata
                frm.Id = entity.KayitId;
                frm.BaseIslemTuru = IslemTuru.EntityUpdate;

                // 3) EN SON YUKLE (Filtre artık doğru çalışır)
                frm.Yukle();
                frm.ShowDialog();
            }
            finally
            {
                frm.Dispose();
            }

            tablo.RefleshDataSource();           
        }
        public override void Temizle()
        {
            base.Temizle();

            tablo.GridControl.DataSource = null;
        }
        protected virtual void TabloEventsYukle()
        {
            if (Tablo == null) return;

            Tablo.DoubleClick -= Tablo_DoubleClick;           

            Tablo.DoubleClick += Tablo_DoubleClick;           
        }
        protected override void Tablo_RowCountChanged(object sender, EventArgs e)
        {
            base.Tablo_RowCountChanged(sender, e);

            ButonlariAyarla();
        }
        private void ButonlariAyarla()
        {
            bool kayitVar = tablo.DataRowCount > 0;

            btnHareketEkle.Visibility = BarItemVisibility.Always;

            btnHareketSil.Visibility = kayitVar ? BarItemVisibility.Always : BarItemVisibility.Never;
            btnBaglantiOzeti.Visibility = kayitVar ? BarItemVisibility.Always : BarItemVisibility.Never;
        }
    }
}