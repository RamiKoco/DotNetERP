using DotNet.ERP.Bll.General.CarilerBll.CariSubeBll;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Dto.CariDto.CariSubeDto;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;
using DevExpress.XtraBars;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.CariForms.CariSubeForms
{
    public partial class CariSubeListForm : BaseListForm
    {
        #region Variables
        private long? _carilerId;
        private string _carilerAdi;
        public long? CarilerId
        {
            get => _carilerId;
            set => _carilerId = value;
        }
        #endregion
        public CariSubeListForm(params object[] prm)
        {
            InitializeComponent();
            Bll = new CariSubeBll();

            //_carilerId = (long)prm[0];
            //_carilerAdi = prm[1].ToString();
            //if (prm.Length > 0 && prm[0] != null)
            //    _carilerId = Convert.ToInt64(prm[0]); // safe cast

            //_carilerAdi = prm.Length > 1 && prm[1] != null ? prm[1].ToString() : string.Empty;
            if (prm.Length > 0 && prm[0] != null)
                _carilerId = (long)prm[0];

            if (prm.Length > 1 && prm[1] != null)
                _carilerAdi = prm[1].ToString();

            btnAdresKartlari.Caption = "Şube Adres Kartı";
            btnIletisimKartlari.Caption = "Şube İletişim Kartı";
            btnAdresKartlari.ItemClick += BarItem_ItemClick;
            btnIletisimKartlari.ItemClick += BarItem_ItemClick;
        }   
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.CariSube;
            Navigator = longNavigator.Navigator;
            tablo.ViewCaption = Text+ $" - ( {_carilerAdi} )";
            //if (IsMdiChild)
            //    ShowItems = new BarItem[] { btnAdresKartlari };//btnIletisimKartlari
        }
        protected override void Listele()
        {    
            if (_carilerId.HasValue) // filtre uygulanacak
                Tablo.GridControl.DataSource = ((CariSubeBll)Bll)
                    .List(x => x.Durum == AktifKartlariGoster && x.CariId == _carilerId.Value);
            else // filtre uygulanmayacak, tüm şubeler
                Tablo.GridControl.DataSource = ((CariSubeBll)Bll)
                    .List(x => x.Durum == AktifKartlariGoster);
        }

        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<CariSubeEditForm>.ShowDialogEditForm(KartTuru.CariSube, id, _carilerId, _carilerAdi);
            ShowEditFormDefault(result);

        }
        private void BarItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            BagliKartAc(e.Item);
        }
        protected override void BagliKartAc(BarItem barItem)
        {
            var entity = Tablo.GetRow<CariSubeL>();
            if (entity == null) return;

            if (barItem == btnAdresKartlari)
            {
                ShowListForms<AdreslerListForm>.ShowListForm(KartTuru.CariSubeAdres, entity.Id, entity.Ad);
            }
            else if (barItem == btnIletisimKartlari)
            {
                ShowListForms<GenelIletisimListForm>.ShowListForm(KartTuru.Iletisim, entity.Id, entity.Ad);
            }
        }
    }
}