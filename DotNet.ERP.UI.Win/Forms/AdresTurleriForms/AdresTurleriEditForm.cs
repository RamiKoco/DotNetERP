using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.UserControls.Controls;
using DevExpress.XtraEditors;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.AdresTurleriForms
{
    public partial class AdresTurleriEditForm : BaseEditForm
    {
        public AdresTurleriEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new Bll.General.AdresTurleriBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.AdresTurleri;
            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Model.Dto.AdresTurleriS() : ((Bll.General.AdresTurleriBll)Bll).Single(Functions.FilterFunctions.Filter<Model.Entities.AdresTurleri>(Id));
            NesneyiKontrollereBagla();
            TabloYukle();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((Bll.General.AdresTurleriBll)Bll).YeniKodVer();
            txtAdresTuruAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Model.Dto.AdresTurleriS)OldEntity;
            txtKod.Text = entity.Kod;
            txtAdresTuruAdi.Text = entity.Ad;
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Model.Entities.AdresTurleri
            {
                Id = Id,
                Kod = txtKod.Text,
                Ad = txtAdresTuruAdi.Text,
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
                    sec.Sec(txtOzelKod1, KartTuru.AdresTurleri);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.AdresTurleri);
        }
    }
}