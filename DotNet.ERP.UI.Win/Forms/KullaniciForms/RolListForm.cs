using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.KullaniciForms
{
    public partial class RolListForm : BaseListForm
    {
        public RolListForm()
        {
            InitializeComponent();
            Bll = new RolBll();

        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Rol;
            FormShow = new ShowEditForms<RolEditForm>();
            Navigator = longNavigator.Navigator;

        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((RolBll)Bll).List(Functions.FilterFunctions.Filter<Rol>(AktifKartlariGoster));
        }

    }
}