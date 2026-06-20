using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.SinifGrupForms
{
    public partial class SinifGrupListForm : BaseListForm
    {
        public SinifGrupListForm()
        {
            InitializeComponent();
            Bll = new SinifGrupBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.SinifGrup;
            FormShow = new ShowEditForms<SinifGrupEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((SinifGrupBll)Bll).List(Functions.FilterFunctions.Filter<SinifGrup>(AktifKartlariGoster));

        }
    }
}