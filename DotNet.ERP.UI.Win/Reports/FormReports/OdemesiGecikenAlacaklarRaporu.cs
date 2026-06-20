using System;
using System.Linq;
using System.Windows.Forms;
using DotNet.ERP.Bll.Functions;
using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Functions;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.UI.Win.Forms.GecikmeAciklamalariForms;
using DotNet.ERP.UI.Win.Forms.MakbuzForms;
using DotNet.ERP.UI.Win.GenelForms;
using DotNet.ERP.UI.Win.Reports.FormReports.Base;
using DotNet.ERP.UI.Win.Show;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Reports.FormReports
{
    public partial class OdemesiGecikenAlacaklarRaporu : BaseRapor
    {
        public OdemesiGecikenAlacaklarRaporu()
        {
            InitializeComponent();
            ShowItems = new BarItem[] { btnBelgeHareketleri, btnTumDetaylariGenislet, btnTumDetaylariDaralt };

        }

        protected override void DegiskenleriDoldur()
        {


            DataLayoutControl = myDataLayoutControl;
            Tablo = tablo;
            Navigator = longNavigator.Navigator;
            Subeler = txtSubeler;
            Odemeler = txtOdemeler;
            BelgeDurumlari = txtBelgeDurumlari;
            KayitSekilleri = txtKayitSekli;
            KayitDurumlari = txtKayitDurumu;
            IptalDurumlari = txtIptalDurumu;
            IlkTarih = txtIlkTarih;
            SonTarih = txtSonTarih;

            SubeKartlariYukle();
            KayitSekliYukle();
            KayitDurumuYukle();
            IptalDurumuYukle();
            OdemeTurleriYukle();
            BelgeDurumuYukle();
            txtIlkTarih.DateTime = DateTime.Now.Date; //AnaForm.DonemParametreleri.DonemBaslamaTarihi;
            txtSonTarih.DateTime = DateTime.Now.Date;
            RaporTuru = KartTuru.OdemesiGecikenAlacaklarRaporu;
        }

        protected override void Listele()
        {
            var subeler = txtSubeler.CheckedComboBoxList<long>();
            var odemeler = txtOdemeler.CheckedComboBoxList<OdemeTipi>();
            var kayitSekli = txtKayitSekli.CheckedComboBoxList<KayitSekli>();
            var kayitDurumu = txtKayitDurumu.CheckedComboBoxList<KayitDurumu>();
            var iptalDurumu = txtIptalDurumu.CheckedComboBoxList<IptalDurumu>();
            var belgeDurumlari = txtBelgeDurumlari.CheckedComboBoxList<BelgeDurumu>();

            using (var bll = new OdemesiGecikenAlacaklarRaporuBll())
            {
                tablo.GridControl.DataSource = bll.List(x =>
                    subeler.Contains(x.Tahakkuk.SubeId) &&
                    odemeler.Contains(x.OdemeTipi) &&
                    kayitSekli.Contains(x.Tahakkuk.KayitSekli) &&
                    kayitDurumu.Contains(x.Tahakkuk.KayitDurumu) &&
                    iptalDurumu.Contains(x.Tahakkuk.Durum ? IptalDurumu.DevamEdiyor : IptalDurumu.IptalEdildi) &&
                    x.Vade >= txtIlkTarih.DateTime.Date && x.Vade <= txtSonTarih.DateTime.Date &&
                    x.Tahakkuk.DonemId == AnaForm.DonemId, belgeDurumlari);

                base.Listele();

            }

        }

        protected override void ShowEditForm()
        {
            var entity = tablo.GetRow<OdemesiGecikenAlacaklarRaporuL>();
            if (entity == null) return;
            ShowListForms<GecikmeAciklamalariListForm>.ShowDialogListForm(KartTuru.Aciklama, null, entity.PortfoyNo);

        }

        protected override void BelgeHareketleri()
        {
            var entity = tablo.GetRow<OdemesiGecikenAlacaklarRaporuL>();
            if (entity == null) return;

            ShowListForms<BelgeHareketleriListForm>.ShowDialogListForm(KartTuru.BelgeHareketleri, null,
                entity.PortfoyNo);

        }

        protected override void BelgeDurumuYukle()
        {
            var enums = Enum.GetValues(typeof(BelgeDurumu));

            foreach (BelgeDurumu entity in enums)
            {
                var item = new CheckedListBoxItem
                {
                    CheckState = CheckState.Checked,
                    Description = entity.ToName(),
                    Value = entity

                };

                if (entity == BelgeDurumu.Portfoyde ||
                    entity == BelgeDurumu.KismiAvukatYoluylaTahsilEtme ||
                    entity == BelgeDurumu.KismiTahsilEdildi ||
                    entity == BelgeDurumu.BankayaTahsileGonderme ||
                    entity == BelgeDurumu.AvukataGonderme ||
                    entity == BelgeDurumu.CiroEtme ||
                    entity == BelgeDurumu.BlokeyeAlma ||
                    entity == BelgeDurumu.OnayBekliyor ||
                    entity == BelgeDurumu.PortfoyeGeriIade ||
                    entity == BelgeDurumu.PortfoyeKarsiliksizIade ||
                    entity == BelgeDurumu.TahsiliImkansizHaleGelme)

                    BelgeDurumlari.Properties.Items.Add(item);


            }

        }

        protected override void Tablo_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;

        }

        protected override void Tablo_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "altGrid";

        }

        protected override void Tablo_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            var entity = tablo.GetRow<OdemesiGecikenAlacaklarRaporuL>(e.RowHandle);
            if (entity == null) return;

            using (var bll = new  GecikmeAciklamalariBll())
            {
                var list = bll.List(x => x.OdemeBilgileriId == entity.PortfoyNo)
                    .EntityListConvert<GecikmeAciklamalariL>().ToList();
                if (list.Any())
                    e.ChildList = list;

            }
        }
    }
}