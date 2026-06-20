using DotNet.ERP.Bll.General.CarilerBll.CariTurleriBll;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Model.Entities.CariEntity.CariTurleri;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DotNet.ERP.UI.Win.Forms.CariForms.CariTurleriForms
{
    public partial class CariTuruListForm : BaseListForm
    {
        #region Variables

        private readonly Expression<Func<CariTuru, bool>> _filter;

        #endregion
        public CariTuruListForm()
        {
            InitializeComponent();
            Bll = new CariTuruBll();
            _filter = x => x.Durum == AktifKartlariGoster;
        }
        public CariTuruListForm(params object[] prm) : this()
        {
            _filter = x => !ListeDisiTutulacakKayitlar.Contains(x.Id) && x.Durum == AktifKartlariGoster;

        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.CariTuru;
            FormShow = new ShowEditForms<CariTuruEditForm>();
            Navigator = longNavigator.Navigator;

        }
        protected override void Listele()
        {

            var list = ((CariTuruBll)Bll).List(_filter);
            Tablo.GridControl.DataSource = list;

            if (!MultiSelect) return;
            if (list.Any())
                EklenebilecekEntityVar = true;
            else
                Messages.KartBulunamadiMesaji("Kart");
        }
    }
}