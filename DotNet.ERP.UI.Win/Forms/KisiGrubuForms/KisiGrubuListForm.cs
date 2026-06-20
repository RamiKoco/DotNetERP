using DotNet.ERP.Bll.General.KisiBll;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities.KisiEntity;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.KisiGrubuForms
{
    public partial class KisiGrubuListForm : BaseListForm
    {
        public KisiGrubuListForm()
        {
            InitializeComponent();
            Bll = new KisiGrubuBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.KisiGrubu;
            FormShow = new ShowEditForms<KisiGrubuEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((KisiGrubuBll)Bll).List(Functions.FilterFunctions.Filter<KisiGrubu>(AktifKartlariGoster));
        }
    }
}