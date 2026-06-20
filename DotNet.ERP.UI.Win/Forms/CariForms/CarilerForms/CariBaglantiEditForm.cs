using DotNet.ERP.Bll.General.CarilerBll;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Dto.CariDto;
using DotNet.ERP.Model.Entities.CariEntity;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.UserControls.UserControl.Base;
using DotNet.ERP.UI.Win.UserControls.UserControl.CariEditFormTable;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.CariForms.CarilerForms
{
    public partial class CariBaglantiEditForm : BaseEditForm
    {
        #region Variables            
        private BaseTablo _iletisimBilgileriTable;
        public long KisiId { get; set; }
        public string KisiAdiSoyadi { get; set; }
        #endregion
        public CariBaglantiEditForm()
        {
            InitializeComponent();
            HideItems = new BarItem[] { btnKaydet, btnSil, btnGerial, btnYeni, btnCikis };
            //ribbonControl.Visible = false;
            foreach (BarItem item in ribbonControl.Items)
                if (item != btnCikis)
                    item.Visibility = BarItemVisibility.Never;

            // Ribbon’ı tamamen küçült (altında boş alan bırakmasın)
            ribbonControl.Minimized = true;

            // Sayfa başlıklarını gizle
            ribbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;

            // Ribbon toolbar kapatılsın
            ribbonControl.ShowToolbarCustomizeItem = false;
            ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;

            // Formun Client alanından ribbon’un alanını düşmesin
            this.Ribbon = null;

            Bll = new CariBll(DataLayoutGenel);
            BaseKartTuru = KartTuru.Cari;

            EventsLoad();

            _iletisimBilgileriTable = new IletisimBilgileriTable().AddTable(this);
            pageIletisimBilgileri.Controls.Add(_iletisimBilgileriTable);

            _iletisimBilgileriTable.Yukle();
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new CariS() : ((CariBll)Bll).Single(Functions.FilterFunctions.Filter<Cari>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
        }

        protected override void GuncelNesneOlustur()
        {
            var entity = (CariS)OldEntity;
            CurrentEntity = new Cari
            {
                Id = Id,
            };
            var kisiText = string.IsNullOrWhiteSpace(KisiAdiSoyadi) ? " - " : KisiAdiSoyadi;
            Text = $"Kişi Bağlantılı İletişim Özeti - ( {KisiAdiSoyadi} | {entity.Unvan} )";
            BagliTabloYukle();
        }

        protected override void BagliTabloYukle()
        {
            //if (_iletisimBilgileriTable != null )
            //    _iletisimBilgileriTable.Yukle();              
            if (_iletisimBilgileriTable != null)
            {
                var table = _iletisimBilgileriTable as IletisimBilgileriTable;
                if (table != null)
                {
                    table.IlgiliKisiId = this.KisiId;  // <-- ARTIK HATA YOK
                    table.Yukle();
                }
            }
        }
        protected override void Control_SelectedPageChanged(object sender, SelectedPageChangedEventArgs e)
        {
            if (e.Page == pageIletisimBilgileri)
            {
                if (pageIletisimBilgileri.Controls.Count == 0)
                {
                    _iletisimBilgileriTable = new IletisimBilgileriTable().AddTable(this);
                    pageIletisimBilgileri.Controls.Add(_iletisimBilgileriTable);

                    _iletisimBilgileriTable.Yukle();
                }

                _iletisimBilgileriTable.Tablo.GridControl.Focus();
            }
        }
    }
}