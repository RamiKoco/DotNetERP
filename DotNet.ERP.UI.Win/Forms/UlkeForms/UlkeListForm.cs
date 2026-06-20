using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.UlkeForms
{
    public partial class UlkeListForm : BaseListForm
    {
        public UlkeListForm()
        {
            InitializeComponent();
            Bll = new Bll.General.UlkeBll();
            //btnBagliKartlar.Caption = "İl Kartları";
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Ulke;
            FormShow = new ShowEditForms<UlkeEditForm>();
            Navigator = longNavigator.Navigator;

            //if (IsMdiChild)
            //    ShowItems = new BarItem[] { btnBagliKartlar };
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((Bll.General.UlkeBll)Bll).List(Functions.FilterFunctions.Filter<Model.Entities.Ulke>(AktifKartlariGoster));

        }

        protected override void BagliKartAc()
        {
            var entity = Tablo.GetRow<Model.Entities.Ulke>();
            //if (entity == null) return;
            //ShowListForms<IlListForm>.ShowListForm(KartTuru.Il, entity.Id, entity.UlkeAdi);
        }
    }
}