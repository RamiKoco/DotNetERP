using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.UlkeForms
{
    public partial class UlkeEditForm : BaseEditForm
    {
        public UlkeEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new Bll.General.UlkeBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Ulke;
            EventsLoad();
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Model.Entities.Ulke() : ((Bll.General.UlkeBll)Bll).Single(FilterFunctions.Filter<Model.Entities.Ulke>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((Bll.General.UlkeBll)Bll).YeniKodVer();
            txtUlkeAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Model.Entities.Ulke)OldEntity;

            txtKod.Text = entity.Kod;
            txtUlkeAdi.Text = entity.UlkeAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Model.Entities.Ulke
            {
                Id = Id,
                Kod = txtKod.Text,
                UlkeAdi = txtUlkeAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButonEnabledDurumu();

        }

    }
}