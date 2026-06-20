using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.KayitKaynakForms
{
    public partial class KayitKaynakListForm : BaseListForm
    {
        public KayitKaynakListForm()
        {
            InitializeComponent();
            Bll = new Bll.General.KayitKaynakBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.KayitKaynak;
            FormShow = new ShowEditForms<KayitKaynakEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((Bll.General.KayitKaynakBll)Bll).List(Functions.FilterFunctions.Filter<Model.Entities.KayitKaynak>(AktifKartlariGoster));

        }
    }
}