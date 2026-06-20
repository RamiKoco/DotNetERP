using DotNet.ERP.Bll.General.KisiBll;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities.KisiEntity;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.KisiGrubuForms
{
    public partial class KisiGrubuEditForm : BaseEditForm
    {
        public KisiGrubuEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new KisiGrubuBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.KisiGrubu;
            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new KisiGrubu() : ((KisiGrubuBll)Bll).Single(Functions.FilterFunctions.Filter<KisiGrubu>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((KisiGrubuBll)Bll).YeniKodVer();
            txtKisiGrubuAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (KisiGrubu)OldEntity;

            txtKod.Text = entity.Kod;
            txtKisiGrubuAdi.Text = entity.Ad;
            tglDurum.IsOn = entity.Durum;

        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new KisiGrubu
            {
                Id = Id,
                Kod = txtKod.Text,
                Ad = txtKisiGrubuAdi.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }
    }
}