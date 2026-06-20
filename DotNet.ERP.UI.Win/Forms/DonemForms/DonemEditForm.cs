using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.DonemForms
{
    public partial class DonemEditForm : BaseEditForm
    {
        public DonemEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new DonemBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Donem;
            EventsLoad();
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Donem() : ((DonemBll)Bll).Single(Functions.FilterFunctions.Filter<Donem>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((DonemBll)Bll).YeniKodVer();
            txtDonemAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Donem)OldEntity;

            txtKod.Text = entity.Kod;
            txtDonemAdi.Text = entity.DonemAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;

        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Donem
            {
                Id = Id,
                Kod = txtKod.Text,
                DonemAdi = txtDonemAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();

        }
    }
}