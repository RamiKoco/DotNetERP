using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.IndirimTuruForms
{
    public partial class IndirimTuruListForm : BaseListForm
    {
        public IndirimTuruListForm()
        {
            InitializeComponent();
            Bll = new IndirimTuruBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.IndirimTuru;
            FormShow = new ShowEditForms<IndirimTuruEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            tablo.GridControl.DataSource = ((IndirimTuruBll)Bll).List(Functions.FilterFunctions.Filter<IndirimTuru>(AktifKartlariGoster));
        }
    }
}