using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.GorevForms
{
    public partial class GorevEditForm : BaseEditForm
    {
        public GorevEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new GorevBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Gorev;
            EventsLoad();
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Gorev() : ((GorevBll) Bll).Single(Functions.FilterFunctions.Filter<Gorev>(Id)); 
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((GorevBll) Bll).YeniKodVer();
            txtGorevAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Gorev) OldEntity;

            txtKod.Text = entity.Kod;
            txtGorevAdi.Text = entity.GorevAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Gorev
            {
                Id = Id,
                Kod = txtKod.Text,
                GorevAdi = txtGorevAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButonEnabledDurumu();
        }
    }
}