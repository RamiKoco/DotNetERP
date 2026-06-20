using DotNet.ERP.Bll.General.PersonelBll;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Dto.PersonelDto;
using DotNet.ERP.Model.Entities.PersonelEntity;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;
using DevExpress.XtraBars;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.PersonelForms
{
    public partial class PersonelListForm : BaseListForm
    {
        public PersonelListForm()
        {
            InitializeComponent();
            Bll = new PersonelBll();

            //btnIletisimKartlari.Caption = "İletişim Kartları";
            btnAdresKartlari.Caption = "Adres Kartları";

            btnIletisimKartlari.ItemClick += BarItem_ItemClick;
            btnAdresKartlari.ItemClick += BarItem_ItemClick;
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Personel;
            FormShow = new ShowEditForms<PersonelEditForm>();
            Navigator = longNavigator.Navigator;

            //if (IsMdiChild)
            //    ShowItems = new BarItem[] {  btnAdresKartlari };//btnIletisimKartlari
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((PersonelBll)Bll).List(Functions.FilterFunctions.Filter<Personel>(AktifKartlariGoster));
        }
        private void BarItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            BagliKartAc(e.Item);
        }
        protected override void BagliKartAc(BarItem barItem)
        {
            var entity = Tablo.GetRow<PersonelL>();
            if (entity == null) return;

            else if (barItem == btnIletisimKartlari)
            {
                ShowListForms<IletisimListForm>.ShowListForm(KartTuru.Iletisim, entity.Id, entity.Ad, entity.Soyad);
            }
            else if (barItem == btnAdresKartlari)
            {
                ShowListForms<AdreslerListForm>.ShowListForm(KartTuru.PersonelAdres, entity.Id, entity.Ad, entity.Soyad);
            }
        }
    }
}