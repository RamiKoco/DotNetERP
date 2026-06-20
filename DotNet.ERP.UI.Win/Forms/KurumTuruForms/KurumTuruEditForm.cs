using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.KurumTuruForms
{
    public partial class KurumTuruEditForm : BaseEditForm
    {
        public KurumTuruEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new KurumTuruBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.KurumTuru;
            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new KurumTuruS() : ((KurumTuruBll)Bll).Single(Functions.FilterFunctions.Filter<KurumTuru>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((KurumTuruBll)Bll).YeniKodVer();
            txtKurumTuruAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (KurumTuruS)OldEntity;

            txtKod.Text = entity.Kod;
            txtKurumTuruAdi.Text = entity.Ad;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new KurumTuru
            {
                Id = Id,
                Kod = txtKod.Text,
                Ad = txtKurumTuruAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButonEnabledDurumu();

        }
    }
}