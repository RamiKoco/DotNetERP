using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.KontenjanForms
{
    public partial class KontenjanEditForm : BaseEditForm
    {
        public KontenjanEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new KontenjanBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Kontenjan;
            EventsLoad();
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Kontenjan() : ((KontenjanBll)Bll).Single(Functions.FilterFunctions.Filter<Kontenjan>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((KontenjanBll)Bll).YeniKodVer();
            txtKontenjanAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Kontenjan)OldEntity;

            txtKod.Text = entity.Kod;
            txtKontenjanAdi.Text = entity.KontenjanAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;

        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Kontenjan
            {
                Id = Id,
                Kod = txtKod.Text,
                KontenjanAdi = txtKontenjanAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();

        }

    }
}