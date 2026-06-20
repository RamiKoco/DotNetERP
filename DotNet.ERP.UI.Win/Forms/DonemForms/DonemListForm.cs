using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using System.Linq.Expressions;
using System;
using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Message;
using DotNet.ERP.UI.Win.Show;
using System.Linq;
using DevExpress.XtraBars;
using DotNet.ERP.UI.Win.GenelForms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.DonemForms
{
    public partial class DonemListForm : BaseListForm
    {
        #region Variables

        private readonly Expression<Func<Donem, bool>> _filter;

        #endregion

        public DonemListForm()
        {
            InitializeComponent();
            Bll = new DonemBll();
            _filter = x => x.Durum == AktifKartlariGoster;
            ShowItems = new BarItem[] { btnParametreler, barF4, barF4Aciklama };
        }

        public DonemListForm(params object[] prm) : this()
        {
            _filter = x => !ListeDisiTutulacakKayitlar.Contains(x.Id) && x.Durum == AktifKartlariGoster;

        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Donem;
            FormShow = new ShowEditForms<DonemEditForm>();
            Navigator = longNavigator.Navigator;

        }

        protected override void Listele()
        {

            var list = ((DonemBll)Bll).List(_filter);
            Tablo.GridControl.DataSource = list;

            if (!MultiSelect) return;
            if (list.Any())
                EklenebilecekEntityVar = true;
            else
                Messages.KartBulunamadiMesaji("Kart");
        }
        protected override void BagliKartAc()
        {
            var entity = Tablo.GetRow<Donem>();
            if (entity == null) return;
            ShowEditForms<DonemParametreEditForm>.ShowDialogEditForm(null, entity.Id);


        }


    }
}