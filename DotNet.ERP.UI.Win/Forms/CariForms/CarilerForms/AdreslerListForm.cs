using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;
using DotNet.ERP.UI.Win.Forms.CariForms;
using DotNet;
using DotNet.ERP;
using DotNet.ERP.UI;
using DotNet.ERP.UI.Win;
using DotNet.ERP.UI.Win.Forms;

namespace DotNet.ERP.UI.Win.Forms.CariForms.CarilerForms
{
    public partial class AdreslerListForm : BaseListForm
    {
        #region Variables
        private readonly long _cariId;
        private readonly string _cariAdi;
        #endregion
        public AdreslerListForm(params object[] prm)
        {
            InitializeComponent();
            Bll = new AdreslerBll();

            _cariId = (long)prm[0];
            _cariAdi = prm[1].ToString();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Adresler;
            Navigator = longNavigator.Navigator;
            Text = "Cari " + Text + $" - ( {_cariAdi} )";
            tablo.ViewCaption = Text;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((AdreslerBll)Bll).List(x => x.Durum == AktifKartlariGoster && x.CariId == _cariId);
        }
        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<CarilerForms.AdreslerEditForm>.ShowDialogEditForm(KartTuru.Adresler, id, _cariId, _cariAdi);
            ShowEditFormDefault(result);

        }
    }
}