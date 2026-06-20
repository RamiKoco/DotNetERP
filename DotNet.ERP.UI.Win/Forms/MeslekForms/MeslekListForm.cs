using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.MeslekForms
{
    public partial class MeslekListForm : BaseListForm
    {
        public MeslekListForm()
        {
            InitializeComponent();
            Bll = new MeslekBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Meslek;
            FormShow = new ShowEditForms<MeslekEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((MeslekBll)Bll).List(Functions.FilterFunctions.Filter<Meslek>(AktifKartlariGoster));

        }
    }
}