using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.PersonelForms
{
    public partial class AdreslerListForm : BaseListForm
    {
        #region Variables
        private readonly long _personelId;
        private readonly string _personelAdi;
        private readonly string _personelSoyadi;
        #endregion
        public AdreslerListForm(params object[] prm)
        {
            InitializeComponent();
            Bll = new AdreslerBll();

            _personelId = (long)prm[0];
            _personelAdi = prm[1].ToString();
            _personelSoyadi = prm[2].ToString();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Adresler;
            Navigator = longNavigator.Navigator;
            Text ="Personel "+ Text + $" - ( {_personelAdi} {_personelSoyadi} )";
            tablo.ViewCaption = Text;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((AdreslerBll)Bll).List(x => x.Durum == AktifKartlariGoster && x.PersonelId == _personelId);
        }
        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<AdreslerEditForm>.ShowDialogEditForm(KartTuru.Adresler, id, _personelId, _personelAdi, _personelSoyadi);
            ShowEditFormDefault(result);

        }
    }
}