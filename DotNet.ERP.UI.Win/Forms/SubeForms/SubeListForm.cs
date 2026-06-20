using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;
using System;
using System.Linq;
using System.Linq.Expressions;
using DotNet.ERP.UI.Win.GenelForms;

namespace DotNet.ERP.UI.Win.Forms.SubeForms
{
    public partial class SubeListForm : BaseListForm
    {
        #region Variables

        private readonly Expression<Func<Sube, bool>> _filter;

        #endregion
        public SubeListForm()
        {
            InitializeComponent();
            Bll = new SubeBll();
            _filter = x => x.Durum == AktifKartlariGoster;
        }
        public SubeListForm(params object[] prm) : this()
        {
            if ((bool)prm[0])
                _filter = x => x.Durum == AktifKartlariGoster && x.Id != AnaForm.SubeId;
            
            else if (!(bool)prm[0])
                _filter = x => !ListeDisiTutulacakKayitlar.Contains(x.Id) &&  x.Durum == AktifKartlariGoster;

        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Sube;
            FormShow = new ShowEditForms<SubeEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((SubeBll)Bll).List(Functions.FilterFunctions.Filter<Sube>(AktifKartlariGoster));

            var list = ((SubeBll)Bll).List(_filter);
            Tablo.GridControl.DataSource = list;

            if (!MultiSelect) return;
            if (list.Any())
                EklenebilecekEntityVar = true;
            else
                Messages.KartBulunamadiMesaji("Kart");
        }

    }
}