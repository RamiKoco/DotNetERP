using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.KimlikTuruForms
{
    public partial class KimlikTuruListForm : BaseListForm
    {
        public KimlikTuruListForm()
        {
            InitializeComponent();
            Bll = new Bll.General.KimlikTuruBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.KimlikTuru;
            FormShow = new ShowEditForms<KimlikTuruEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((Bll.General.KimlikTuruBll)Bll).List(Functions.FilterFunctions.Filter<Model.Entities.KimlikTuru>(AktifKartlariGoster));
        }
    }
}