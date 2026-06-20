using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.RehberForms
{
    public partial class RehberListForm : BaseListForm
    {
        public RehberListForm()
        {
            InitializeComponent();
            Bll = new RehberBll();

        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Rehber;
            FormShow = new ShowEditForms<RehberEditForm>();
            Navigator = longNavigator.Navigator;

        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((RehberBll)Bll).List(Functions.FilterFunctions.Filter<Rehber>(AktifKartlariGoster));

        }

    }
}