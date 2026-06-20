using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.CariForms.CariSubeForms
{
    public partial class GenelIletisimListForm : BaseListForm
    {
        #region Variables
        private readonly long _cariSubeId;
        private readonly string _cariSubeAdi;
        #endregion
        public GenelIletisimListForm(params object[] prm)
        {
            InitializeComponent();
            Bll = new IletisimBll();

            _cariSubeId = (long)prm[0];
            _cariSubeAdi = prm[1].ToString();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Iletisim;
            Navigator = longNavigator.Navigator;
            Text = "Cari Şube " + Text + $" - ( {_cariSubeAdi} )";
            tablo.ViewCaption = Text;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((IletisimBll)Bll).List(x => x.Durum == AktifKartlariGoster && x.CariSubeId == _cariSubeId);
        }
        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<IletisimEditForm>.ShowDialogEditForm(KartTuru.Iletisim, id, _cariSubeId, _cariSubeAdi);
            ShowEditFormDefault(result);
        }
    }
}