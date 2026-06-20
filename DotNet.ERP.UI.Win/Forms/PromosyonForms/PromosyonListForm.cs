using System;
using System.Linq;
using System.Linq.Expressions;
using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.GenelForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.PromosyonForms
{
    public partial class PromosyonListForm : BaseListForm
    {
        #region Variables

        private readonly Expression<Func<Promosyon, bool>> _filter;

        #endregion

        public PromosyonListForm()
        {
            InitializeComponent();
            Bll = new PromosyonBll();
            _filter = x => x.Durum == AktifKartlariGoster && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId;
        }

        public PromosyonListForm(params object[] prm):this()
        {
            _filter = x => !ListeDisiTutulacakKayitlar.Contains(x.Id) && x.Durum == AktifKartlariGoster && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Promosyon;
            FormShow = new ShowEditForms<PromosyonEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            var list = ((PromosyonBll)Bll).List(_filter);
            Tablo.GridControl.DataSource = list;

            if (!MultiSelect) return;
            if (list.Any())
                EklenebilecekEntityVar = true;
            else
                Messages.KartBulunamadiMesaji("Kart");
        }
    }
}