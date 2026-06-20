using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DevExpress.XtraEditors;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.KontenjanForms.KurumlarForms
{
    public partial class KurumlarEditForm : BaseEditForm
    {
        public KurumlarEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new KurumlarBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Kurumlar;
            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new KurumlarS() : ((KurumlarBll)Bll).Single(Functions.FilterFunctions.Filter<Kurumlar>(Id));
            NesneyiKontrollereBagla();
            TabloYukle();
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((KurumlarBll)Bll).YeniKodVer();
            txtKurumAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (KurumlarS)OldEntity;
            txtKod.Text = entity.Kod;
            txtKurumAdi.Text = entity.Ad;
            txtKurumTuru.Id = entity.KurumTuruId;
            txtKurumTuru.Text = entity.KurumTuruAdi;
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Kurumlar
            {
                Id = Id,
                Kod = txtKod.Text,
                Ad = txtKurumAdi.Text,
                KurumTuruId = txtKurumTuru.Id,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id = txtOzelKod2.Id,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }
        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new Functions.SelectFunctions())
                if (sender == txtOzelKod1)
                    sec.Sec(txtOzelKod1, KartTuru.Kurumlar);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.Kurumlar);
                else if (sender == txtKurumTuru)
                    sec.Sec(txtKurumTuru, KartTuru.Kurumlar);


        }
    }
}