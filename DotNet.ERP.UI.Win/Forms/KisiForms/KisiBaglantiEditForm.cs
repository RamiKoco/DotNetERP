using DotNet.ERP.Bll.General.KisiBll;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities.KisiEntity;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.UserControls.UserControl.Base;
using DotNet.ERP.UI.Win.UserControls.UserControl.KisiEditFormTable;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.KisiForms
{
    public partial class KisiBaglantiEditForm : BaseEditForm
    {

        #region Variables            
        private BaseTablo _iletisimBilgileriTable;     
        public string KisiAdiSoyadi { get; set; }       // gösterilecek ad-soyad (örn "Ahmet Yılmaz"
        #endregion

        public KisiBaglantiEditForm()
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
            
            ribbonControl.ShowToolbarCustomizeItem = false;
            ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;

            this.Ribbon = null;

            Bll = new KisiBll(DataLayoutGenel);
            BaseKartTuru = KartTuru.Kisi;

            EventsLoad();

            _iletisimBilgileriTable = new IletisimBilgileriTable().AddTable(this);
            pageIletisimBilgileri.Controls.Add(_iletisimBilgileriTable);

            //_iletisimBilgileriTable.Yukle();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Model.Dto.KisiDto.KisiS() : ((KisiBll)Bll).Single(Functions.FilterFunctions.Filter<Kisi>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);

        }
        protected override void GuncelNesneOlustur()
        {
            var entity = (Model.Dto.KisiDto.KisiS)OldEntity;
            CurrentEntity = new Kisi
            {
                Id = Id,
            };
            var kisiText = string.IsNullOrWhiteSpace(KisiAdiSoyadi) ? " - " : KisiAdiSoyadi;
            Text = $"Kişi Bağlantılı İletişim Özeti - ( {entity.Ad}  {entity.Soyad})";
            BagliTabloYukle();
        }

        protected override void BagliTabloYukle()
        {
            //if (_iletisimBilgileriTable != null)
            //    _iletisimBilgileriTable.Yukle();
            if (_iletisimBilgileriTable != null)
            {
                var table = _iletisimBilgileriTable as IletisimBilgileriTable;
                if (table != null)
                {
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