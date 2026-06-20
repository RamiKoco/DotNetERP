using DotNet.ERP.Bll.General.KisiBll;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities.KisiEntity;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;
using DevExpress.XtraBars;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.KisiForms
{
    public partial class KisiListForm : BaseListForm
    {
        public KisiListForm()
        {
            InitializeComponent();
            Bll = new KisiBll();

            btnAdresKartlari.Caption = "Adres Kartları";
            btnIletisimKartlari.Caption = "İletişim Kartları";

            btnIletisimKartlari.ItemClick += BarItem_ItemClick;
            btnAdresKartlari.ItemClick += BarItem_ItemClick;
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Kisi;
            FormShow = new ShowEditForms<KisiEditForm>();
            Navigator = longNavigator.Navigator;

            //if (IsMdiChild)
            //    ShowItems = new BarItem[] {  btnAdresKartlari };//btnIletisimKartlari
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((KisiBll)Bll).List(Functions.FilterFunctions.Filter<Kisi>(AktifKartlariGoster));
        }
        private void BarItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            BagliKartAc(e.Item);
        }
        protected override void BagliKartAc(BarItem barItem)
        {
            var entity = Tablo.GetRow<Model.Dto.KisiDto.KisiL>();
            if (entity == null) return;

            if (barItem == btnIletisimKartlari)
            {
                ShowListForms<IletisimListForm>.ShowListForm(KartTuru.KisiIletisim, entity.Id, entity.Ad, entity.Soyad);
            }
            else if (barItem == btnAdresKartlari)
            {
                ShowListForms<AdreslerListForm>.ShowListForm(KartTuru.KisiAdres, entity.Id, entity.Ad, entity.Soyad);
            }
        }
    }
}