using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.UI.Win.Forms.TahakkukForms;
using DotNet.ERP.UI.Win.GenelForms;
using DotNet.ERP.UI.Win.Show;
using DotNet.ERP.UI.Win.UserControls.UserControl.Base;
using DevExpress.XtraBars;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.UserControls.UserControl.TahakkukEditFormTable
{
    public partial class TahakkukBilgileriTable : BaseTablo
    {
        public TahakkukBilgileriTable()
        {
            InitializeComponent();

            Bll = new TahakkukBll();
            Tablo = tablo;
            EventsLoad();

            insUptNavigator.Navigator.Buttons.Append.Visible = false;
            insUptNavigator.Navigator.Buttons.Remove.Visible = false;
            insUptNavigator.Navigator.Buttons.PrevPage.Visible = true;
            insUptNavigator.Navigator.Buttons.NextPage.Visible = true;

            HideItems = new BarItem[] {btnHareketEkle,btnHareketSil };
            ShowItems = new BarItem[] {btnKartDuzenle };


        }

        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((TahakkukBll)Bll).OgrenciTahakkukList(x => x.OgrenciId == OwnerForm.Id);
        }

        protected override void OpenEntity()
        {
            var entity = tablo.GetRow<OgrenciTahakkukL>();
            if (entity == null) return;
            ShowEditForms<TahakkukEditForm>.ShowDialogEditForm(KartTuru.Tahakkuk, entity.TahakkukId, entity.SubeId != AnaForm.SubeId || entity.DonemId != AnaForm.DonemId);

        }
    }
}
