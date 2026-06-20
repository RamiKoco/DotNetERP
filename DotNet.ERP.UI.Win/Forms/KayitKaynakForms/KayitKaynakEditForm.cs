using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.KayitKaynakForms
{
    public partial class KayitKaynakEditForm : BaseEditForm
    {
        public KayitKaynakEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new Bll.General.KayitKaynakBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.KayitKaynak;
            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Model.Entities.KayitKaynak() : ((Bll.General.KayitKaynakBll)Bll).Single(Functions.FilterFunctions.Filter<Model.Entities.KayitKaynak>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((Bll.General.KayitKaynakBll)Bll).YeniKodVer();
            txtKayitKaynakAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Model.Entities.KayitKaynak)OldEntity;

            txtKod.Text = entity.Kod;
            txtKayitKaynakAdi.Text = entity.Ad;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;

        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Model.Entities.KayitKaynak
            {
                Id = Id,
                Kod = txtKod.Text,
                Ad = txtKayitKaynakAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }
    }
}