using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.YabancıDilForms
{
    public partial class YabanciDilEditForm : BaseEditForm
    {
        public YabanciDilEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new YabancıDilBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.YabanciDil;
            EventsLoad();
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new YabanciDil() : ((YabancıDilBll)Bll).Single(Functions.FilterFunctions.Filter<YabanciDil>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((YabancıDilBll)Bll).YeniKodVer();
            txtDilAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (YabanciDil)OldEntity;

            txtKod.Text = entity.Kod;
            txtDilAdi.Text = entity.DilAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;

        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new YabanciDil
            {
                Id = Id,
                Kod = txtKod.Text,
                DilAdi = txtDilAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }

    }
}