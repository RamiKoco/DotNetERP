using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Forms.IlceForms;
using DotNet.ERP.UI.Win.Show;
using DevExpress.XtraBars;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.IlForms
{
    public partial class IlListForm : BaseListForm
    {
        public IlListForm()
        {
            InitializeComponent();
            Bll = new IlBll();
            btnBagliKartlar.Caption = "İlçe Kartları";
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Il;
            FormShow = new ShowEditForms<IlEditForm>();
            Navigator = longNavigator.Navigator;

            if (IsMdiChild)
                ShowItems = new BarItem[] {btnBagliKartlar};
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((IlBll) Bll).List(Functions.FilterFunctions.Filter<Il>(AktifKartlariGoster));

        }

        protected override void BagliKartAc()
        {
            var entity = Tablo.GetRow<Il>();
            if (entity == null) return;
            ShowListForms<IlceListForm>.ShowListForm(KartTuru.Ilce,entity.Id,entity.Ad);
        }
    }
}