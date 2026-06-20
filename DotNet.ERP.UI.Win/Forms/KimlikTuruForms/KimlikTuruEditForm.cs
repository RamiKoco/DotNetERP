using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.UserControls.Controls;
using DevExpress.XtraEditors;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.KimlikTuruForms
{
    public partial class KimlikTuruEditForm : BaseEditForm
    {
        public KimlikTuruEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new Bll.General.KimlikTuruBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.KimlikTuru;
            EventsLoad();
            txtKarakterTipi.Properties.Items.Clear();
            txtKarakterTipi.Properties.Items.AddRange(new[] { "Numeric", "AlphaNumeric" });
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Model.Dto.KimlikTuruS() : ((Bll.General.KimlikTuruBll)Bll).Single(Functions.FilterFunctions.Filter<Model.Entities.KimlikTuru>(Id));
            NesneyiKontrollereBagla();
            TabloYukle();
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((Bll.General.KimlikTuruBll)Bll).YeniKodVer();
            txtKimlikTuruAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Model.Dto.KimlikTuruS)OldEntity;
            txtKod.Text = entity.Kod;
            txtKimlikTuruAdi.Text = entity.Ad;
            txtUlke.Id = entity.UlkeId;
            txtUlke.Text = entity.UlkeAdi;
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
            txtKarakterTipi.Text = entity.KarakterTipi;
            txtUzunluk.EditValue = entity.Uzunluk;
        }

        protected override void GuncelNesneOlustur()
        {
            int uzunluk = 0;
            int.TryParse(txtUzunluk.Text, out uzunluk);
            CurrentEntity = new Model.Entities.KimlikTuru
            {
                Id = Id,
                Kod = txtKod.Text,
                Ad = txtKimlikTuruAdi.Text,
                UlkeId = txtUlke.Id,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id = txtOzelKod2.Id,
                KarakterTipi = txtKarakterTipi.SelectedItem?.ToString() ?? "",
                Uzunluk = uzunluk,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }
        protected override void SecimYap(object sender)
        {
            if (sender is MyButtonEdit mbe && mbe.IsClearButtonClick)
                return;
            if (!(sender is ButtonEdit)) return;

            using (var sec = new Functions.SelectFunctions())
                if (sender == txtOzelKod1)
                    sec.Sec(txtOzelKod1, KartTuru.KimlikTuru);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.KimlikTuru);
                else if (sender == txtUlke)
                    sec.Sec(txtUlke, KartTuru.KimlikTuru);


        }
    }
}