using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.UserControls.Controls;
using DevExpress.XtraEditors;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.BelgeTuruForms
{
    public partial class BelgeTuruEditForm : BaseEditForm
    {
        public BelgeTuruEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new BelgeTuruBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.BelgeTuru;
            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new BelgeTuruS() : ((BelgeTuruBll)Bll).Single(Functions.FilterFunctions.Filter<BelgeTuru>(Id));
            NesneyiKontrollereBagla();
            TabloYukle();
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((BelgeTuruBll)Bll).YeniKodVer();
            txtBelgeAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (BelgeTuruS)OldEntity;
            txtKod.Text = entity.Kod;
            txtBelgeAdi.Text = entity.Ad;
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new BelgeTuru
            {
                Id = Id,
                Kod = txtKod.Text,
                Ad = txtBelgeAdi.Text,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id = txtOzelKod2.Id,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }
        protected override void SecimYap(object sender)
        {
            if (sender is MyButtonEdit mbe && mbe.IsClearButtonClick)
                return;
            if (!(sender is ButtonEdit)) return;

            using (var sec = new Functions.SelectFunctions())
                if (sender == txtOzelKod1)
                    sec.Sec(txtOzelKod1, KartTuru.BelgeTuru);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.BelgeTuru);

        }
    }
}