using System;
using System.Linq;
using System.Linq.Expressions;
using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.GenelForms;
using DotNet.ERP.UI.Win.Show;
using DevExpress.Utils.Extensions;

namespace DotNet.ERP.UI.Win.Forms.HizmetForms
{
    public partial class HizmetListForm : BaseListForm
    {
        #region Variables

        private readonly Expression<Func<Hizmet, bool>> _filter; 
        
        #endregion
        public HizmetListForm()
        {
            InitializeComponent();
            Bll = new HizmetBll();
            _filter = x => x.Durum == AktifKartlariGoster && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId;

        }

        public HizmetListForm(params object[] prm) : this()
        {
            if (prm != null)
            {
                var panelGoster = (bool)prm[0];
                ustPanel.Visible = DateTime.Now.Date > AnaForm.DonemParametreleri.EgitimBaslamaTarihi && panelGoster;
            }
            
            _filter = x => !ListeDisiTutulacakKayitlar.Contains(x.Id) && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId && x.Durum == AktifKartlariGoster;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Hizmet;
            FormShow = new ShowEditForms<HizmetEditForm>();
            Navigator = longNavigator.Navigator;
            TarihAyarla();
        }

        protected override void Listele()
        {
            var list = ((HizmetBll)Bll).List(_filter);
            Tablo.GridControl.DataSource = list;

            if (!MultiSelect) return;
            if (list.Any())
                EklenebilecekEntityVar = true;
            else
                Messages.KartBulunamadiMesaji("Kart");
        }

        private void TarihAyarla()
        {
            txtHizmetBaslamaTarihi.Properties.MinValue = AnaForm.DonemParametreleri.GunTarihininOncesineHizmetBaslamaTarihiGirilebilir ? AnaForm.DonemParametreleri.EgitimBaslamaTarihi : DateTime.Now.Date < AnaForm.DonemParametreleri.EgitimBaslamaTarihi ? AnaForm.DonemParametreleri.EgitimBaslamaTarihi : DateTime.Now.Date;
            txtHizmetBaslamaTarihi.Properties.MaxValue = AnaForm.DonemParametreleri.GunTarihininSonrasinaHizmetBaslamaTarihiGirilebilir ? AnaForm.DonemParametreleri.DonemBitisTarihi : DateTime.Now.Date < AnaForm.DonemParametreleri.EgitimBaslamaTarihi ? AnaForm.DonemParametreleri.EgitimBaslamaTarihi : DateTime.Now.Date > AnaForm.DonemParametreleri.DonemBitisTarihi ? AnaForm.DonemParametreleri.DonemBitisTarihi : DateTime.Now.Date;
            txtHizmetBaslamaTarihi.DateTime = DateTime.Now.Date <= AnaForm.DonemParametreleri.EgitimBaslamaTarihi ? AnaForm.DonemParametreleri.EgitimBaslamaTarihi : DateTime.Now.Date > AnaForm.DonemParametreleri.EgitimBaslamaTarihi && DateTime.Now.Date <= AnaForm.DonemParametreleri.DonemBitisTarihi ? DateTime.Now.Date : DateTime.Now.Date > AnaForm.DonemParametreleri.DonemBitisTarihi ? AnaForm.DonemParametreleri.DonemBitisTarihi : DateTime.Now.Date;
        }

        protected override void SelectEntity()
        {
            base.SelectEntity();

            if (MultiSelect)
                SelectedEntities.ForEach(x => ((HizmetL)x).BaslamaTarihi = txtHizmetBaslamaTarihi.DateTime.Date);
        }
    }
}