using DotNet.ERP.Bll.General.CarilerBll.CariSubeBll;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Model.Dto.CariDto.CariSubeDto;
using DotNet.ERP.Model.Entities.CariEntity.CariSube;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Forms.CariForms.CariSubeForms;
using DotNet.ERP.UI.Win.Show;
using DotNet.ERP.UI.Win.UserControls.UserControl.Base;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.UserControls.UserControl.CariEditFormTable
{
    public partial class CariSubelerTable : BaseTablo
    {
        private bool IslemYapilabilir => OwnerForm is BaseEditForm frm && frm.BaseIslemTuru != IslemTuru.EntityInsert;
        public CariSubelerTable()
        {
            InitializeComponent();

            Bll = new CariSubeBll();
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

            var list = ((CariSubeBll)Bll)
                .List(x => x.CariId == OwnerForm.Id)
                .ToBindingList<CariSubeL>();

            if (Tablo?.GridControl != null)
                Tablo.GridControl.DataSource = list;
        }
        protected internal override bool HataliGiris()
        {
            if (!TableValueChanged) return false;
            if (tablo.HasColumnErrors) tablo.ClearColumnErrors();

            for (int i = 0; i < tablo.DataRowCount; i++)
            {
                var entity = tablo.GetRow<CariSubeL>(i);

                if (!tablo.HasColumnErrors) continue;
                Messages.TabloEksikBilgiMesaji($"{tablo.ViewCaption} Tablosu");
                return true;
            }

            return false;
        }
        protected override void OpenEntity()
        {
            //var entity = tablo.GetRow<CariSubeL>();
            //if (entity == null) return;
            //ShowEditForms<CariEditForm>.ShowDialogEditForm(KartTuru.Cari, entity.Id);
            CariSubeKartiAc();
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
        private void CariSubeKartiAc()
        {
            var entity = Tablo.GetFocusedRow() as CariSubeL;
            if (entity == null) return;

            ShowEditForms<CariSubeEditForm>.ShowDialogEditForm(
                KartTuru.CariSube,
                entity.Id
            );

            Listele();
        }
        protected override void HareketEkle()
        {
            var result = ShowEditForms<CariSubeEditForm>.ShowDialogEditForm(
                KartTuru.CariSube,
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

            var row = Tablo.GetRow<CariSubeL>();
            if (row == null)
                return;

            // 🔴 Yeni eklenmiş ama DB’ye gitmemiş
            if (row.Id == 0)
            {
                var list = Tablo.DataController.ListSource as IList<CariSubeL>;
                list?.Remove(row);
            }
            else
            {
                // 🔴 GERÇEK SİLME (Entity ile)
                using (var bll = new CariSubeBll())
                {
                    bll.Delete(new CariSube { Id = row.Id });
                }
            }

            Listele();
            ButonEnabledDurumu(true);
        }
        public override void Temizle()
        {
            base.Temizle();
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
            btnDuzelt.Visibility = kayitVar ? BarItemVisibility.Always : BarItemVisibility.Never;
        }
    }
}
