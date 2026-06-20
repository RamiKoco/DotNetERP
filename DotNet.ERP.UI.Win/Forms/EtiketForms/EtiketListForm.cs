using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.EtiketForms
{
    public partial class EtiketListForm : BaseListForm
    {
        public EtiketListForm()
        {
            InitializeComponent();
            Bll = new Bll.General.EtiketBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Etiket;
            FormShow = new ShowEditForms<EtiketEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((Bll.General.EtiketBll)Bll).List(Functions.FilterFunctions.Filter<Model.Entities.Etiket>(AktifKartlariGoster));
        }     
    }
}