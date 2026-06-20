using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.TesvikForms
{
    public partial class TesvikListForm : BaseListForm
    {
        public TesvikListForm()
        {
            InitializeComponent();
            Bll = new TesvikBll();

        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Tesvik;
            FormShow = new ShowEditForms<TesvikEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((TesvikBll) Bll).List(Functions.FilterFunctions.Filter<Tesvik>(AktifKartlariGoster));

        }
    }
}