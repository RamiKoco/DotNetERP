using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.SosyalMedyaForms
{
    public partial class SosyalMedyaPlatformuListForm : BaseListForm
    {
        public SosyalMedyaPlatformuListForm()
        {
            InitializeComponent();
            Bll = new Bll.General.SosyalMedyaPlatformuBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.SosyalMedyaPlatformu;
            FormShow = new ShowEditForms<SosyalMedyaPlatformuEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((Bll.General.SosyalMedyaPlatformuBll)Bll).List(Functions.FilterFunctions.Filter<Model.Entities.SosyalMedyaPlatformu>(AktifKartlariGoster));
        }
    }
}