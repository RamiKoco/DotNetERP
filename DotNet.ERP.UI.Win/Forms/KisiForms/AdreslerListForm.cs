using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.KisiForms
{
    public partial class AdreslerListForm : BaseListForm
    {
        #region Variables
        private readonly long _kisiId;
        private readonly string _kisiAdi;
        private readonly string _kisiSoyadi;
        #endregion
        public AdreslerListForm(params object[] prm)
        {
            InitializeComponent();
            Bll = new AdreslerBll();

            _kisiId = (long)prm[0];
            _kisiAdi = prm[1].ToString();
            _kisiSoyadi = prm[2].ToString();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Adresler;
            Navigator = longNavigator.Navigator;
            Text = "Kişi "+Text + $" - ( {_kisiAdi} {_kisiSoyadi} )";
            tablo.ViewCaption = Text;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((AdreslerBll)Bll)
                  .List(x => x.Durum == AktifKartlariGoster && x.KayitId == _kisiId);
        }
        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<AdreslerEditForm>.ShowDialogEditForm(KartTuru.Adresler, id, _kisiId, _kisiAdi, _kisiSoyadi);
            ShowEditFormDefault(result);

        }
    }
}