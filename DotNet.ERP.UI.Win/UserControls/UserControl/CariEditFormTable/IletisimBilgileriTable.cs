using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;
using DotNet.ERP.UI.Win.UserControls.UserControl.Base;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.UserControls.UserControl.CariEditFormTable
{
    public partial class IletisimBilgileriTable : BaseTablo
    {
        public long? IlgiliKisiId { get; set; }
        private bool IslemYapilabilir => OwnerForm is BaseEditForm frm && frm.BaseIslemTuru != IslemTuru.EntityInsert;
        private string _lastSelectedPageName;
        public IletisimBilgileriTable()
        {
            InitializeComponent();

            Bll = new IletisimBll();
            Tablo = tablo;
            EventsLoad();

            //ShowItems = new BarItem[] { btnDuzelt, btnHareketEkle, btnHareketSil};
            btnHareketEkle.Caption = "Yeni";
            btnHareketSil.Caption = "Sil";
            btnDuzelt.ItemClick += (s, e) => OpenEntity();

            solPane.SelectedPageChanged += NavigationPane_SelectedPageChanged;
            insUptNavigator.Visible = false;
            smallNavigatorTelefon.Navigator.NavigatableControl = Tablo.GridControl;
            smallNavigatorEPosta.Navigator.NavigatableControl = Tablo.GridControl;
            smallNavigatorWeb.Navigator.NavigatableControl = Tablo.GridControl;
            smallNavigatorSosyalMedya.Navigator.NavigatableControl = Tablo.GridControl;

            solPane.SelectedPage = pageTelefon;
            solPane.State = NavigationPaneState.Expanded;
            solPane.StateChanging += SolPane_StateChanging;
        }
        protected override void OpenEntity()
        {
            IletisimKartAc();
        }
        private void SolPane_StateChanging(object sender, StateChangingEventArgs e)
        {
            if (e.State == NavigationPaneState.Collapsed)
                e.Cancel = true;
        }
        private void NavigationPane_SelectedPageChanged(object sender, SelectedPageChangedEventArgs e)
        {
            var selectedPage = e.Page as NavigationPage;
            DegiskenleriDoldur();

            switch (selectedPage?.Name)
            {
                case "pageTelefon":
                    smallNavigatorTelefon.Navigator.NavigatableControl = Tablo.GridControl;
                    break;

                case "pageWeb":
                    smallNavigatorWeb.Navigator.NavigatableControl = Tablo.GridControl;
                    break;

                case "pageEPosta":
                    smallNavigatorEPosta.Navigator.NavigatableControl = Tablo.GridControl;
                    break;

                case "pageSosyalMedya":
                    smallNavigatorSosyalMedya.Navigator.NavigatableControl = Tablo.GridControl;
                    break;
            }
            TabloEventsYukle();   // 🔥 ÇOK ÖNEMLİ
            Listele();
            ButonlariAyarla();
        }

        protected internal override void Listele()
        {
            if (solPane.SelectedPage == null) return;
            var bll = (IletisimBll)Bll;
            int tur = 0;
            int tur2 = -1;            
            var pageName = solPane.SelectedPage?.Name ?? _lastSelectedPageName;
            switch (solPane.SelectedPage.Name)
            {
                case "pageTelefon":
                    tur = (int)IletisimTuru.Telefon;
                    tur2 = (int)IletisimTuru.Fax;
                    Tablo = tablo;
                    break;

                case "pageEPosta":
                    tur = (int)IletisimTuru.EPosta;
                    Tablo = epostaTablo;
                    break;

                case "pageWeb":
                    tur = (int)IletisimTuru.Web;
                    Tablo = webTablo;
                    break;

                case "pageSosyalMedya":
                    tur = (int)IletisimTuru.SosyalMedya;
                    Tablo = sosyalMedyaTablo;
                    break;
            }
            
            if (this.IlgiliKisiId > 0)
            {
                var list = ((IletisimBll)Bll)
                   .List(x =>
                       x.CariId == OwnerForm.Id &&
                       (x.IletisimTuru == (IletisimTuru)tur ||
                        x.IletisimTuru == (IletisimTuru)tur2) &&
                       x.IlgiliKisiId == this.IlgiliKisiId   // <-- BURASI: yalnızca bu kişiye bağlı olanlar
                   ).ToBindingList<IletisimL>();

                Tablo.GridControl.DataSource = list;
                return;
            }

            // fallback: IlgiliKisiId==0 ise eski davranış
            var list2 = ((IletisimBll)Bll)
               .List(x =>
                   x.CariId == OwnerForm.Id &&
                   (x.IletisimTuru == (IletisimTuru)tur ||
                    x.IletisimTuru == (IletisimTuru)tur2)
               ).ToBindingList<IletisimL>();

            Tablo.GridControl.DataSource = list2;
        }

        protected internal override bool HataliGiris()
        {
            if (!TableValueChanged) return false;
            if (tablo.HasColumnErrors) tablo.ClearColumnErrors();

            for (int i = 0; i < tablo.DataRowCount; i++)
            {
                var entity = tablo.GetRow<IletisimL>(i);

                if (!tablo.HasColumnErrors) continue;
                Messages.TabloEksikBilgiMesaji($"{tablo.ViewCaption} Tablosu");
                return true;
            }

            return false;
        }

        protected override void DegiskenleriDoldur()
        {

            switch (solPane.SelectedPage.Name)
            {

                case "pageTelefon":
                    Tablo = tablo;
                    break;

                case "pageWeb":
                    Tablo = webTablo;
                    break;

                case "pageEPosta":
                    Tablo = epostaTablo;
                    break;

                case "pageSosyalMedya":
                    Tablo = sosyalMedyaTablo;
                    break;

            }
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
        private void IletisimKartAc()
        {
            var entity = Tablo.GetFocusedRow() as IletisimL;
            if (entity == null) return;

            ShowEditForms<Forms.CariForms.CarilerForms.IletisimEditForm>.ShowDialogEditForm(
                KartTuru.Iletisim,
                entity.Id
            );

            Listele();
        }
        protected override void HareketEkle()
        {
            var result = ShowEditForms<Forms.CariForms.CarilerForms.IletisimEditForm>.ShowDialogEditForm(
                KartTuru.Iletisim,
                0,                  // 🔴 yeni kayıt
                OwnerForm.Id        // 🔴 carilId
                                    // Unvan  yoksa göndermiyoruz
            );
            Listele();
        }
        protected override void HareketSil()
        {
            if (!IslemYapilabilir)
                return;

            if (Tablo.DataRowCount == 0) return;

            var row = Tablo.GetRow<IletisimL>();
            if (row == null)
                return;

            // 🔴 Yeni eklenmiş ama DB’ye gitmemiş
            if (row.Id == 0)
            {
                var list = Tablo.DataController.ListSource as IList<IletisimL>;
                list?.Remove(row);
            }
            else
            {
                // 🔴 GERÇEK SİLME (Entity ile)
                using (var bll = new IletisimBll())
                {
                    bll.Delete(new Iletisim { Id = row.Id });
                }
            }

            Listele();
            ButonEnabledDurumu(true);
        }
        public override void Temizle()
        {
            base.Temizle();

            epostaTablo.GridControl.DataSource = null;
            webTablo.GridControl.DataSource = null;
            sosyalMedyaTablo.GridControl.DataSource = null;

            _lastSelectedPageName = null;
            IlgiliKisiId = null;
        }
        protected override void Tablo_RowCountChanged(object sender, EventArgs e)
        {
            base.Tablo_RowCountChanged(sender, e);

            ButonlariAyarla();
        }
        private void ButonlariAyarla()
        {
            bool kayitVar = Tablo != null && Tablo.DataRowCount > 0;

            btnHareketEkle.Visibility = BarItemVisibility.Always;
            btnHareketSil.Visibility = kayitVar ? BarItemVisibility.Always : BarItemVisibility.Never;
            btnDuzelt.Visibility = kayitVar ? BarItemVisibility.Always : BarItemVisibility.Never;
        }
    }
}
