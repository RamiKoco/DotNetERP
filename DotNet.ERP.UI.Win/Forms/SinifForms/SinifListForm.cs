using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.GenelForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.SinifForms
{
    public partial class SinifListForm : BaseListForm
    {
        public SinifListForm()
        {
            InitializeComponent();
            Bll = new SinifBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Sinif;
            FormShow = new ShowEditForms<SinifEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((SinifBll)Bll).List(X => X.Durum == AktifKartlariGoster && X.SubeId == AnaForm.SubeId);
        }
    }
}