using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.PozisyonForms
{
    public partial class PozisyonListForm : BaseListForm
    {
        public PozisyonListForm()
        {
            InitializeComponent();
            Bll = new Bll.General.PozisyonBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Pozisyon;
            FormShow = new ShowEditForms<PozisyonEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((Bll.General.PozisyonBll)Bll).List(Functions.FilterFunctions.Filter<Model.Entities.Pozisyon>(AktifKartlariGoster));
        }
    }
}