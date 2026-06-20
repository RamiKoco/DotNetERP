using DotNet.ERP.Bll.General.CarilerBll;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Dto.CariDto;
using DotNet.ERP.Model.Entities.CariEntity;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Forms.CariForms.CariSubeForms;
using DotNet.ERP.UI.Win.Show;
using DevExpress.XtraBars;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.CariForms.CarilerForms
{
    public partial class CariListForm : BaseListForm
    {
        public CariListForm()
        {
            InitializeComponent();
            Bll = new CariBll();

            btnBagliKartlar.Caption = "Cari Şube";
            btnIletisimKartlari.Caption = "Cari İletişim";
            btnAdresKartlari.Caption = "Cari Adres";

            btnBagliKartlar.ItemClick += BarItem_ItemClick;
            btnIletisimKartlari.ItemClick += BarItem_ItemClick;
            btnAdresKartlari.ItemClick += BarItem_ItemClick;

        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Cari;
            FormShow = new ShowEditForms<CarilerForms.CariEditForm>();
            Navigator = longNavigator.Navigator;

            if (IsMdiChild)
                ShowItems = new BarItem[] { btnBagliKartlar};//btnIletisimKartlari, btnAdresKartlari 
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((CariBll)Bll).List(Functions.FilterFunctions.Filter<Cari>(AktifKartlariGoster));
        }
        private void BarItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            BagliKartAc(e.Item);
        }
        protected override void BagliKartAc(BarItem barItem)
        {
            var entity = Tablo.GetRow<CariL>();
            if (entity == null) return;           

            if (barItem == btnBagliKartlar)
            {
                ShowListForms<CariSubeListForm>.ShowListForm(KartTuru.CariSube, entity.Id, entity.Unvan);
            }

            else if (barItem == btnIletisimKartlari)
            {
                ShowListForms<CarilerForms.GenelIletisimListForm>.ShowListForm(KartTuru.Iletisim, entity.Id, entity.Unvan);
            }
            else if (barItem == btnAdresKartlari)
            {
                ShowListForms<CarilerForms.AdreslerListForm>.ShowListForm(KartTuru.Adresler, entity.Id, entity.Unvan);
            }
        }
    }
}