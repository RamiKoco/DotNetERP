using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.CariForms.CarilerForms
{
    public partial class GenelIletisimListForm : BaseListForm
    {
        #region Variables
        private readonly long _cariId;
        private readonly string _cariAdi;
        #endregion
        public GenelIletisimListForm(params object[] prm)
        {
            InitializeComponent();
            Bll = new IletisimBll();

            _cariId = (long)prm[0];
            _cariAdi = prm[1].ToString();

        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Iletisim;
            Navigator = longNavigator.Navigator;
            Text = "Cari " + Text + $" - ( {_cariAdi} )";
            tablo.ViewCaption = Text;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((IletisimBll)Bll).List(x => x.Durum == AktifKartlariGoster && x.CariId == _cariId);
        }
        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<CarilerForms.IletisimEditForm>.ShowDialogEditForm(KartTuru.Iletisim, id, _cariId, _cariAdi);
            ShowEditFormDefault(result);

        }
    }
}