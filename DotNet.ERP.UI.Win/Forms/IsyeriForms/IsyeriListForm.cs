using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.IsyeriForms
{
    public partial class IsyeriListForm : BaseListForm
    {
        public IsyeriListForm()
        {
            InitializeComponent();
            Bll = new IsyeriBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Isyeri;
            FormShow = new ShowEditForms<IsyeriEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((IsyeriBll)Bll).List(Functions.FilterFunctions.Filter<Isyeri>(AktifKartlariGoster));

        }
    }
}