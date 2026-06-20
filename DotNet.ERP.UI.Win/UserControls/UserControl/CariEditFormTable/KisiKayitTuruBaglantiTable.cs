using DotNet.ERP.Bll.General.CarilerBll;
using DotNet.ERP.Bll.General.KisiBll;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Model.Dto.CariDto;
using DotNet.ERP.Model.Entities.KisiEntity;
using DotNet.ERP.UI.Win.Forms.KisiForms;
using DotNet.ERP.UI.Win.Show;
using DotNet.ERP.UI.Win.UserControls.UserControl.Base;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.UserControls.UserControl.CariEditFormTable
{
    public partial class KisiKayitTuruBaglantiTable : BaseTablo
    {
        private KayitTuru _kayitTuru;

        private ShowEditForms<KisiEditForm> FormShow;

        public KisiKayitTuruBaglantiTable()
        {
            InitializeComponent();

            Bll = new KisiKayitTuruBaglantiBll();
            Tablo = tablo;
            EventsLoad();
            // FormShow örneğini ayarla (KisiEditForm açmak için)
            FormShow = new ShowEditForms<KisiEditForm>();
            //ShowItems = new BarItem[] { btnKisiBaglantiOzeti };
            //btnKisiBaglantiOzeti.Enabled = false;

            btnKisiBaglantiOzeti.ItemClick += (s, e) => IletisimGoster();
            tablo.FocusedRowChanged += (s, e) => ButonDurumGuncelle();
            tablo.CellValueChanged += (s, e) => ButonDurumGuncelle();
            tablo.ShownEditor += (s, e) =>
            {
                if (tablo.FocusedColumn == colKisiAdi && tablo.ActiveEditor != null)
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
                .List(x => x.KayitId == OwnerForm.Id)
                .ToBindingList<KisiKayitTuruBaglantiL>();
        }

        protected override void HareketEkle()
        {
            var source = tablo.DataController.ListSource;

            if (OwnerForm is Forms.CariForms.CarilerForms.CariEditForm)
                _kayitTuru = KayitTuru.Cari;           
            else
                _kayitTuru = KayitTuru.CariSube; 

            var row = new KisiKayitTuruBaglantiL
            {
                KayitId = OwnerForm.Id,
                KayitTuru = _kayitTuru,
                Insert = true
            };

            source.Add(row);
            tablo.Focus();
            tablo.RefleshDataSource();
            tablo.FocusedRowHandle = tablo.DataRowCount - 1;
            tablo.FocusedColumn = colKisiAdi;
            ButonEnabledDurumu(true);
        }

        protected override void Tablo_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            base.Tablo_CellValueChanged(sender, e);

            if (e.Column != colKisiId) return;

            var entity = tablo.GetRow<KisiKayitTuruBaglantiL>();
            if (entity == null) return;

            var list = tablo.DataController.ListSource as IList<KisiKayitTuruBaglantiL>;
            if (list == null) return;

            if (entity.KisiId != null && list.Any(x => x.KisiId == entity.KisiId && !ReferenceEquals(x, entity)))
            {
                Messages.UyariMesaji("Bu kişi zaten listede mevcut! Satır iptal edildi.");

                tablo.CloseEditor();
                tablo.CancelUpdateCurrentRow();
                tablo.HideEditor();

                try { entity.KisiAdi = null; } catch { }

                tablo.BeginUpdate();
                if (list.Contains(entity))
                    list.Remove(entity);
                tablo.EndUpdate();

                tablo.RefleshDataSource();
                tablo.RefreshData();
                tablo.ClearSelection();
                tablo.FocusedRowHandle = GridControl.InvalidRowHandle;

                return;
            }

            if (entity.KisiId == null) return;


            using (var bll = new KisiBll())
            {
                var kisi = (Kisi)bll.Single(x => x.Id == entity.KisiId);
                if (kisi == null) return;

                if (entity.KayitTuru == KayitTuru.Cari)
                {
                    entity.Kod = kisi.Kod;
                    entity.KisiAdi = kisi.Ad;
                }
                else
                {
                    entity.Kod = kisi.Kod;
                    entity.KisiAdi = kisi.Ad + " " + kisi.Soyad;
                }
            }

            tablo.RefleshDataSource();
        }

        protected override void Tablo_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            base.Tablo_FocusedColumnChanged(sender, e);

            if (e.FocusedColumn == colKisiAdi)
                e.FocusedColumn.Sec(tablo, insUptNavigator.Navigator, repositoryKisi, colKisiId);

            if (e.FocusedColumn == colPozisyonAdi)
                e.FocusedColumn.Sec(tablo, insUptNavigator.Navigator, repositoryPozisyon, colPozisyonId);
        }

        public bool KaydetKontrollu()
        {
            if (!(tablo.DataController.ListSource is IList<KisiKayitTuruBaglantiL> list) || !list.Any())
                return true;

            var invalidRows = list.Where(x =>
                string.IsNullOrWhiteSpace(x.KisiAdi) ||
                x.KayitId == 0
            ).ToList();

            if (invalidRows.Any())
            {
                string message = $"Toplam {invalidRows.Count} kayıt hatalı.\n" +
                                 "Kişi seçimi yapılmamış kayıtlar kaydedilemez.";
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
                if (row.Id == 0 || row.Insert)
                {
                    list.Remove(row); // henüz kaydedilmemiş satır
                }
                else
                {
                    row.Delete = true; // veritabanında silinecek
                }

                Tablo.RefleshDataSource();
                ButonEnabledDurumu(true);
            }
        }
        private void IletisimGoster()
        {
            var entity = tablo.GetRow<KisiKayitTuruBaglantiL>();
            if (entity == null)
            {
                Messages.HataMesaji("Lütfen bir satır seçiniz.");
                return;
            }

            if (entity.KisiId == null)
            {
                Messages.UyariMesaji("Bu satıra ait kişi seçilmemiş.");
                return;
            }

            // Statik metot olarak tip üzerinden çağır
            // ShowEditForms<KisiEditForm>.ShowDialogEditForm(long, params object[])
            ShowEditForms<KisiBaglantiEditForm>.ShowDialogEditForm(entity.KisiId.Value);

            // Form kapandıktan sonra tabloyu yenile (güncelleme olduysa gözüksün)
            tablo.RefleshDataSource();
            ButonEnabledDurumu(true);
        }

        private void Editor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.Delete)
            {
                var view = tablo;

                view.SetRowCellValue(view.FocusedRowHandle, colKisiAdi, string.Empty);
                view.SetRowCellValue(view.FocusedRowHandle, colKodKisi, string.Empty);
                view.SetRowCellValue(view.FocusedRowHandle, colKisiId, 0);

                view.CloseEditor();      // editörü kapat
                view.UpdateCurrentRow(); // row'u güncelle

                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void ButonDurumGuncelle()
        {
            var entity = tablo.GetRow<KisiKayitTuruBaglantiL>();
            btnKisiBaglantiOzeti.Enabled = entity != null && entity.KayitId != 0;
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
                    (entity.KayitId == 0 || string.IsNullOrWhiteSpace(entity.KisiAdi)))
                {
                    tablo.FocusedRowHandle = i;
                    tablo.SetColumnError(colKisiAdi, "Kayıt seçilmeli ve geçerli olmalı.");
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
            btnKisiBaglantiOzeti.Visibility = kayitVar ? BarItemVisibility.Always : BarItemVisibility.Never;
        }
    }
}