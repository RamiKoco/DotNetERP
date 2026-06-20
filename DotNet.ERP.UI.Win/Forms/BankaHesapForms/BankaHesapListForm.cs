using System;
using System.Linq.Expressions;
using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.GenelForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.BankaHesapForms
{
    public partial class BankaHesapListForm : BaseListForm
    {
        #region Variables

        private readonly Expression<Func<BankaHesap, bool>> _filter;
        private readonly BankaHesapTuru _hesapTuru = BankaHesapTuru.VadesizMevduatHesabi;
        #endregion
        public BankaHesapListForm()
        {
            InitializeComponent();
            Bll = new BankaHesapBll();
            _filter = x => x.Durum == AktifKartlariGoster && x.SubeId == AnaForm.SubeId;
        }

        public BankaHesapListForm(params object[] prm) : this()
        {
            if (prm[0].GetType() == typeof(BankaHesapTuru))
                _hesapTuru = (BankaHesapTuru) prm[0];

            else if (prm[0].GetType() == typeof(OdemeTipi))
            {
                var odemeTipi = (OdemeTipi) prm[0];

                switch (odemeTipi)
                {
                    case OdemeTipi.Epos:
                        _hesapTuru = BankaHesapTuru.EposBlokeHesabi;
                        break;
                    case OdemeTipi.Ots:
                        _hesapTuru = BankaHesapTuru.OtsBlokeHesabi;
                        break;
                    case OdemeTipi.Pos:
                        _hesapTuru = BankaHesapTuru.PosBlokeHesabi;
                        break;
                }
            }

            _filter = x => x.Durum == AktifKartlariGoster && x.HesapTuru == _hesapTuru && x.SubeId == AnaForm.SubeId;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.BankaHesap;
            FormShow = new ShowEditForms<BankaHesapEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((BankaHesapBll)Bll).List(_filter);
        }
    }
}