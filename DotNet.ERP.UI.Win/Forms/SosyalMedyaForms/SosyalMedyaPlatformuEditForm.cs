using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.UserControls.Controls;
using DevExpress.XtraEditors;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.SosyalMedyaForms
{
    public partial class SosyalMedyaPlatformuEditForm : BaseEditForm
    {
        public SosyalMedyaPlatformuEditForm()
        {
            InitializeComponent();


            DataLayoutControl = myDataLayoutControl;
            Bll = new Bll.General.SosyalMedyaPlatformuBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.SosyalMedyaPlatformu;
            EventsLoad();
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Model.Dto.SosyalMedyaPlatformuS() : ((Bll.General.SosyalMedyaPlatformuBll)Bll).Single(Functions.FilterFunctions.Filter<Model.Entities.SosyalMedyaPlatformu>(Id));
            NesneyiKontrollereBagla();
            TabloYukle();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((Bll.General.SosyalMedyaPlatformuBll)Bll).YeniKodVer();
            txtAd.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Model.Dto.SosyalMedyaPlatformuS)OldEntity;
            txtKod.Text = entity.Kod;
            txtAd.Text = entity.Ad;
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Model.Entities.SosyalMedyaPlatformu
            {
                Id = Id,
                Kod = txtKod.Text,
                Ad = txtAd.Text,
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
                    sec.Sec(txtOzelKod1, KartTuru.SosyalMedyaPlatformu);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.SosyalMedyaPlatformu);
        }
    }
}