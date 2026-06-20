using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.AdreslerForms
{
    public partial class AdresListForm : BaseListForm
    {
        public AdresListForm()
        {
            InitializeComponent();
            Bll = new AdreslerBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Adresler;
            FormShow = new ShowEditForms<AdreslerForms.AdresEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((AdreslerBll)Bll).List(Functions.FilterFunctions.Filter<Adresler>(AktifKartlariGoster));
        }
    }
}