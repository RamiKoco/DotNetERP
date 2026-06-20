using DotNet.ERP.Bll.Functions;
using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Forms.TahakkukForms;
using DotNet.ERP.UI.Win.GenelForms;
using DotNet.ERP.UI.Win.Show;
using DevExpress.XtraBars;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.OgrenciForms
{
    public partial class OgrenciListForm : BaseListForm
    {
        public OgrenciListForm()
        {
            InitializeComponent();
            Bll = new OgrenciBll();
            ShowItems = new BarItem[] {btnTahakkukYap};
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Ogrenci;
            FormShow = new ShowEditForms<OgrenciEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((OgrenciBll) Bll).List(Functions.FilterFunctions.Filter<Ogrenci>(AktifKartlariGoster));
        }

        protected override void TahakkukYap()
        {
            var entity = tablo.GetRow<OgrenciL>().EntityConvert<Ogrenci>();

            using (var bll = new TahakkukBll())
            {
                var tahakkuk = bll.SingleSummary(x => x.OgrenciId == entity.Id && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);

                if (tahakkuk != null)
                    ShowEditForms<TahakkukEditForm>.ShowDialogEditForm(KartTuru.Tahakkuk, tahakkuk.Id,null);
                else
                    ShowEditForms<TahakkukEditForm>.ShowDialogEditForm(KartTuru.Tahakkuk, -1, entity);

            }
        }
    }
}