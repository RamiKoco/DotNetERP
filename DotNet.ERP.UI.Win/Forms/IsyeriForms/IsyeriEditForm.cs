using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.IsyeriForms
{
    public partial class IsyeriEditForm : BaseEditForm
    {
        public IsyeriEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new IsyeriBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Isyeri;
            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Isyeri() : ((IsyeriBll)Bll).Single(Functions.FilterFunctions.Filter<Isyeri>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((IsyeriBll)Bll).YeniKodVer();
            txtIsyeriAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Isyeri)OldEntity;

            txtKod.Text = entity.Kod;
            txtIsyeriAdi.Text = entity.IsyeriAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;

        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Isyeri
            {
                Id = Id,
                Kod = txtKod.Text,
                IsyeriAdi = txtIsyeriAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }
    }
}