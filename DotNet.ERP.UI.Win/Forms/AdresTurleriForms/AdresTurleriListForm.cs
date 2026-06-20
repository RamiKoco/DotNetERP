using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.AdresTurleriForms
{
    public partial class AdresTurleriListForm : BaseListForm
    {
        public AdresTurleriListForm()
        {
            InitializeComponent();
            Bll = new Bll.General.AdresTurleriBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.AdresTurleri;
            FormShow = new ShowEditForms<AdresTurleriEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((Bll.General.AdresTurleriBll)Bll).List(Functions.FilterFunctions.Filter<Model.Entities.AdresTurleri>(AktifKartlariGoster));
        }
    }
}