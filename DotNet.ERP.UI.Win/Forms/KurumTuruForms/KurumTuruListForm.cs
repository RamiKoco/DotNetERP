using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.KurumTuruForms
{
    public partial class KurumTuruListForm : BaseListForm
    {
        public KurumTuruListForm()
        {
            InitializeComponent();
            Bll = new KurumTuruBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.KurumTuru;
            FormShow = new ShowEditForms<KurumTuruEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((KurumTuruBll)Bll).List(Functions.FilterFunctions.Filter<KurumTuru>(AktifKartlariGoster));
        }
    }
}