using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.UyrukForms
{
    public partial class UyrukListForm : BaseListForm
    {
        public UyrukListForm()
        {
            InitializeComponent();
            Bll = new Bll.General.UyrukBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Uyruk;
            FormShow = new ShowEditForms<UyrukEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((Bll.General.UyrukBll)Bll).List(Functions.FilterFunctions.Filter<Model.Entities.Uyruk>(AktifKartlariGoster));
        }
    }
}