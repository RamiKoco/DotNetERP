using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.KisiForms
{
    public partial class IletisimListForm : BaseListForm
    {
        #region Variables
        private readonly long _kisiId;
        private readonly string _kisiAdi;
        private readonly string _kisiSoyadi;
        #endregion
        public IletisimListForm(params object[] prm)
        {
            InitializeComponent();
            Bll = new IletisimBll();

            _kisiId = (long)prm[0];
            _kisiAdi = prm[1].ToString();
            _kisiSoyadi = prm[2].ToString();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Iletisim;
            Navigator = longNavigator.Navigator;
            Text ="Kişi "+ Text + $" - ( {_kisiAdi} {_kisiSoyadi} )";
            tablo.ViewCaption = Text;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((IletisimBll)Bll).List(x => x.Durum == AktifKartlariGoster && x.KisiId == _kisiId);
        }
        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<Iletisim2EditForm>.ShowDialogEditForm(KartTuru.Iletisim, id, _kisiId, _kisiAdi, _kisiSoyadi);
            ShowEditFormDefault(result);

        }
    }
}