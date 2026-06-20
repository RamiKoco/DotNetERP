using DotNet.ERP.Bll.General.CarilerBll.CariSubeBll;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities.CariEntity.CariSube;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.CariForms.CariSubeForms.CariSubeGrubuForms
{
    public partial class CariSubeGrubuListForm : BaseListForm
    {      
        public CariSubeGrubuListForm()
        {
            InitializeComponent();
            Bll = new CariSubeGrubuBll();
        }       
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.CariSubeGrubu;
            FormShow = new ShowEditForms<CariSubeGrubuEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((CariSubeGrubuBll)Bll).List(Functions.FilterFunctions.Filter<CariSubeGrubu>(AktifKartlariGoster));
        }
    }
}