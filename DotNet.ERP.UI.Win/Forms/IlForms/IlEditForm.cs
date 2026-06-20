using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.IlForms
{
    public partial class IlEditForm : BaseEditForm
    {
        public IlEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new IlBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Il;
            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Il() : ((IlBll)Bll).Single(Functions.FilterFunctions.Filter<Il>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((IlBll)Bll).YeniKodVer();
            txtIlAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Il)OldEntity;

            txtKod.Text = entity.Kod;
            txtIlAdi.Text = entity.Ad;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Il
            {
                Id = Id,
                Kod = txtKod.Text,
                Ad = txtIlAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButonEnabledDurumu();

        }
    }
}