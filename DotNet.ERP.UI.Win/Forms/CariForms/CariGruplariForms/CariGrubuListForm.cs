using DotNet.ERP.Bll.General.CarilerBll.CariGruplariBll;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Model.Entities.CariEntity.CariGruplari;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DotNet.ERP.UI.Win.Forms.CariForms.CariGruplariForms
{
    public partial class CariGrubuListForm : BaseListForm
    {
        #region Variables

        private readonly Expression<Func<CariGrubu, bool>> _filter;

        #endregion
        public CariGrubuListForm()
        {
            InitializeComponent();
            Bll = new CariGrubuBll();
            _filter = x => x.Durum == AktifKartlariGoster;
        }
        public CariGrubuListForm(params object[] prm) : this()
        {
            _filter = x => !ListeDisiTutulacakKayitlar.Contains(x.Id) && x.Durum == AktifKartlariGoster;
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.CariGrubu;
            FormShow = new ShowEditForms<CariGrubuEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {

            var list = ((CariGrubuBll)Bll).List(_filter);
            Tablo.GridControl.DataSource = list;
            if (!MultiSelect) return;
            if (list.Any())
                EklenebilecekEntityVar = true;
            else
                Messages.KartBulunamadiMesaji("Kart");
        }
    }
}