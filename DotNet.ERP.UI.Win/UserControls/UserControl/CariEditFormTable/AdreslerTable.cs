using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;
using DotNet.ERP.UI.Win.UserControls.UserControl.Base;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.UserControls.UserControl.CariEditFormTable
{
    public partial class AdreslerTable : BaseTablo
    {
        private bool IslemYapilabilir => OwnerForm is BaseEditForm frm && frm.BaseIslemTuru != IslemTuru.EntityInsert;
        public AdreslerTable()
        {
            InitializeComponent();

            Bll = new AdreslerBll();
            Tablo = tablo;
            EventsLoad();
            TabloEventsYukle();

            //ShowItems = new BarItem[] { btnDuzelt, btnHareketEkle, btnHareketSil };
            btnHareketEkle.Caption = "Yeni";
            btnHareketSil.Caption = "Sil";
            btnDuzelt.ItemClick += (s, e) => OpenEntity();

            //insUptNavigator.Navigator.Buttons.Append.Visible = false;
            //insUptNavigator.Navigator.Buttons.Remove.Visible = false;
            //insUptNavigator.Navigator.Buttons.Edit.Visible = false;
        } 
        protected internal override void Listele()
        {
            var list = ((AdreslerBll)Bll)
                .List(x => x.KayitId == OwnerForm.Id)
                .ToBindingList<AdreslerL>();

            if (Tablo?.GridControl != null)
                Tablo.GridControl.DataSource = list;
        }
        protected internal override bool HataliGiris()
        {
            if (!TableValueChanged) return false;
            if (tablo.HasColumnErrors) tablo.ClearColumnErrors();

            for (int i = 0; i < tablo.DataRowCount; i++)
            {
                var entity = tablo.GetRow<AdreslerL>(i);

                if (!tablo.HasColumnErrors) continue;
                Messages.TabloEksikBilgiMesaji($"{tablo.ViewCaption} Tablosu");
                return true;
            }

            return false;
        }
        protected override void OpenEntity()
        {
            //var entity = tablo.GetRow<AdreslerL>();
            //if (entity == null) return;
            //ShowEditForms<CariEditForm>.ShowDialogEditForm(KartTuru.Cari, entity.Id);
            AdresKartiAc();
        }
        protected virtual void TabloEventsYukle()
        {
            if (Tablo == null) return;
            Tablo.RowCountChanged -= Tablo_RowCountChanged;
            Tablo.DoubleClick -= Tablo_DoubleClick;
            Tablo.KeyDown -= Tablo_KeyDown;
            Tablo.MouseUp -= Tablo_MouseUp;

            Tablo.RowCountChanged += Tablo_RowCountChanged;
            Tablo.DoubleClick += Tablo_DoubleClick;
            Tablo.KeyDown += Tablo_KeyDown;
            Tablo.MouseUp += Tablo_MouseUp;  
        }
        protected override void Tablo_MouseUp(object sender, MouseEventArgs e)
        {
            if (!IslemYapilabilir)
                return;
            if (popupMenu == null || e.Button != MouseButtons.Right)
                return;

            popupMenu.ShowPopup(Cursor.Position);
        }       
        private void AdresKartiAc()
        {
            var entity = Tablo.GetFocusedRow() as AdreslerL;
            if (entity == null) return;

            ShowEditForms<Forms.CariForms.CarilerForms.AdreslerEditForm>.ShowDialogEditForm(
                KartTuru.Adresler,
                entity.Id
            );

            Listele();
        }
        protected override void HareketEkle()
        {
            var result = ShowEditForms<Forms.CariForms.CarilerForms.AdreslerEditForm>.ShowDialogEditForm(
                KartTuru.Adresler,
                0,               
                OwnerForm.Id  
                                  
            );
            Listele();
        }
        protected override void HareketSil()
        {
            if (!IslemYapilabilir)
                return;

            if (Tablo.DataRowCount == 0) return;

            var row = Tablo.GetRow<AdreslerL>();
            if (row == null)
                return;

            // 🔴 Yeni eklenmiş ama DB’ye gitmemiş
            if (row.Id == 0)
            {
                var list = Tablo.DataController.ListSource as IList<AdreslerL>;
                list?.Remove(row);
            }
            else
            {
                // 🔴 GERÇEK SİLME (Entity ile)
                using (var bll = new AdreslerBll())
                {
                    bll.Delete(new Adresler { Id = row.Id });
                }
            }

            Listele();
            ButonEnabledDurumu(true);
        }
        public override void Temizle()
        {
            base.Temizle();
        }
        //protected override void Tablo_RowCountChanged(object sender, EventArgs e)
        //{
        //    base.Tablo_RowCountChanged(sender, e);

        //    bool kayitVar = tablo.DataRowCount > 0;

        //    // 🔹 Base butonlar
        //    btnHareketSil.Enabled = kayitVar;
        //    btnDuzelt.Enabled = kayitVar;

        //    btnHareketEkle.Enabled = true;
        //}
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
            btnDuzelt.Visibility = kayitVar ? BarItemVisibility.Always : BarItemVisibility.Never;
        }
    }
}
