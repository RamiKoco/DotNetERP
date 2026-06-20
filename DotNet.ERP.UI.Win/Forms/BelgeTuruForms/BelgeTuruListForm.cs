using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.BelgeTuruForms
{
    public partial class BelgeTuruListForm : BaseListForm
    {
        public BelgeTuruListForm()
        {
            InitializeComponent();
            Bll = new BelgeTuruBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.BelgeTuru;
            FormShow = new ShowEditForms<BelgeTuruEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((BelgeTuruBll)Bll).List(Functions.FilterFunctions.Filter<BelgeTuru>(AktifKartlariGoster));
        }
    }
}