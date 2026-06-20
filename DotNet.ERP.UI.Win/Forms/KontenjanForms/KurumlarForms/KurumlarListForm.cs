using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.KontenjanForms.KurumlarForms
{
    public partial class KurumlarListForm : BaseListForm
    {
        public KurumlarListForm()
        {
            InitializeComponent();
            Bll = new KurumlarBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Kurumlar;
            FormShow = new ShowEditForms<KurumlarForms.KurumlarEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((KurumlarBll)Bll).List(Functions.FilterFunctions.Filter<Kurumlar>(AktifKartlariGoster));
        }
    }
}