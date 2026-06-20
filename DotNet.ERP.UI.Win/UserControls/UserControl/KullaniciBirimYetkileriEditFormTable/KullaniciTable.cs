using DotNet.ERP.Bll.General;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.UI.Win.Forms.KullaniciForms;
using DotNet.ERP.UI.Win.UserControls.UserControl.Base;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.UserControls.UserControl.KullaniciBirimYetkileriEditFormTable
{
    public partial class KullaniciTable : BaseTablo
    {
        public KullaniciTable()
        {
            InitializeComponent();

            Bll = new KullaniciBll();
            Tablo = tablo;
            EventsLoad();

            HideItems = new BarItem[] { btnHareketEkle, btnHareketSil };
            insUptNavigator.Navigator.Buttons.Append.Visible = false;
            insUptNavigator.Navigator.Buttons.Remove.Visible = false;
            insUptNavigator.Navigator.Buttons.PrevPage.Visible = false;
            insUptNavigator.Navigator.Buttons.NextPage.Visible = false;

        }
        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((KullaniciBll)Bll).List(null);
        }
        protected override void HareketSil() { }

        protected override void Tablo_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            var entity = tablo.GetRow<KullaniciL>();
            if (entity == null) return;

            OwnerForm.Id = entity.Id;
            ((KullaniciBirimYetkileriEditForm)OwnerForm).Yukle();
        }
    }
}
