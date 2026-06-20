using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.IptalNedeniForms
{
    public partial class IptalNedeniListForm : BaseListForm
    {
        public IptalNedeniListForm()
        {
            InitializeComponent();
            Bll = new IptalNedeniBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.IptalNedeni;
            FormShow = new ShowEditForms<IptalNedeniEditForm>();
            Navigator = longNavigator.Navigator;

        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((IptalNedeniBll)Bll).List(Functions.FilterFunctions.Filter<IptalNedeni>(AktifKartlariGoster));

        }
    }
}