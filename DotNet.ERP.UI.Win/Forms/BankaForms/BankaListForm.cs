using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BankaSubeForms;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;
using DevExpress.XtraBars;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.BankaForms
{
    public partial class BankaListForm : BaseListForm
    {
        public BankaListForm()
        {
            InitializeComponent();
            Bll = new BankaBll();
            btnBagliKartlar.Caption = "Şube Kartları";
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Banka;
            FormShow = new ShowEditForms<BankaEditForm>();
            Navigator = longNavigator.Navigator;

            if (IsMdiChild)
                ShowItems = new BarItem[] {btnBagliKartlar};

        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((BankaBll) Bll).List(Functions.FilterFunctions.Filter<Banka>(AktifKartlariGoster));
        }

        protected override void BagliKartAc()
        {
            var entity = Tablo.GetRow<BankaL>();
            if (entity == null) return;
            ShowListForms<BankaSubeListForm>.ShowListForm(KartTuru.BankaSube, entity.Id, entity.BankaAdi);
        }
    }
}