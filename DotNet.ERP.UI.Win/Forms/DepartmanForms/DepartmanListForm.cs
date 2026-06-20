using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.DepartmanForms
{
    public partial class DepartmanListForm : BaseListForm
    {
        public DepartmanListForm()
        {
            InitializeComponent();
            Bll = new Bll.General.DepartmanBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Departman;
            FormShow = new ShowEditForms<DepartmanEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((Bll.General.DepartmanBll)Bll).List(Functions.FilterFunctions.Filter<Model.Entities.Departman>(AktifKartlariGoster));
        }
    }
}