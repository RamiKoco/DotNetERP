using DotNet.ERP.Bll.General;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.OkulForms
{
    public partial class OkulListForm : BaseListForm
    {
        public OkulListForm()
        {
            InitializeComponent();
            Bll = new OkulBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Okul;
            FormShow = new ShowEditForms<OkulEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((OkulBll)Bll).List(Functions.FilterFunctions.Filter<Okul>(AktifKartlariGoster));
        }
    }
}