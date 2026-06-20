using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DotNet.ERP.UI.Win.Forms.SektorForms
{
    public partial class SektorListForm :BaseListForm
    {
        #region Variables

        private readonly Expression<Func<Sektor, bool>> _filter;

        #endregion
        public SektorListForm()
        {
            InitializeComponent();
            Bll = new SektorBll();
            _filter = x => x.Durum == AktifKartlariGoster;
        }
        public SektorListForm(params object[] prm) : this()
        {
            _filter = x => !ListeDisiTutulacakKayitlar.Contains(x.Id) && x.Durum == AktifKartlariGoster;
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Sektor;
            FormShow = new ShowEditForms<SektorEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {

            var list = ((SektorBll)Bll).List(_filter);
            Tablo.GridControl.DataSource = list;
            if (!MultiSelect) return;
            if (list.Any())
                EklenebilecekEntityVar = true;
            else
                Messages.KartBulunamadiMesaji("Kart");
        }
    }
}