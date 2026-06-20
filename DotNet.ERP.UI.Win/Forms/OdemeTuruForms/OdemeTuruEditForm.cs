using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Functions;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.OdemeTuruForms
{
    public partial class OdemeTuruEditForm : BaseEditForm
    {
        public OdemeTuruEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new OdemeTuruBll(myDataLayoutControl);
            txtOdemeTipi.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<OdemeTipi>());
            BaseKartTuru = KartTuru.OdemeTuru;
            EventsLoad();

        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new OdemeTuru() : ((OdemeTuruBll) Bll).Single(Functions.FilterFunctions.Filter<OdemeTuru>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((OdemeTuruBll) Bll).YeniKodVer();
            txtOdemeTuruAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (OdemeTuru) OldEntity;

            txtKod.Text = entity.Kod;
            txtOdemeTuruAdi.Text = entity.OdemeTuruAdi;
            txtOdemeTipi.SelectedItem = entity.OdemeTipi.ToName();
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new OdemeTuru
            {
                Id = Id,
                Kod = txtKod.Text,
                OdemeTuruAdi = txtOdemeTuruAdi.Text,
                OdemeTipi = txtOdemeTipi.Text.GetEnum<OdemeTipi>(),
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn

            };
            ButonEnabledDurumu();

        }
    }
}