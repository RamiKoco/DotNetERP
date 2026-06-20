using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.YakinlikForms
{
    public partial class YakinlikListForm : BaseListForm
    {
        public YakinlikListForm()
        {
            InitializeComponent();
            Bll = new YakinlikBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Yakinlik;
            FormShow = new ShowEditForms<YakinlikEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((YakinlikBll)Bll).List(Functions.FilterFunctions.Filter<Yakinlik>(AktifKartlariGoster));

        }

    }
}