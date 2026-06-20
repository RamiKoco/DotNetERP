using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.IletisimlerForms
{
    public partial class IletisimListForm : BaseListForm
    {
        public IletisimListForm()
        {
            InitializeComponent();
            Bll = new IletisimBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Iletisim;
            FormShow = new ShowEditForms<IletisimEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((IletisimBll)Bll).List(Functions.FilterFunctions.Filter<Iletisim>(AktifKartlariGoster));
        }
    }
}