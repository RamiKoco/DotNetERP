using System.Security;
using System.Windows.Forms;
using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.KullaniciForms
{
    public partial class KullaniciEditForm : BaseEditForm
    {
        private string _sifre;
        private string _gizliKelime;
        private SecureString _secureSifre;
        private SecureString _secureGizliKelime;
        private bool _tekrarGonder;
        public KullaniciEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new KullaniciBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Kullanici;
            ShowItems = new BarItem[] { btnSifreSifirla };
            EventsLoad();

        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new KullaniciS() : ((KullaniciBll)Bll).Single(Functions.FilterFunctions.Filter<Kullanici>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKullaniciAdi.Text = "Yeni Kullanıcı";
            btnSifreSifirla.Enabled = false;
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (KullaniciS)OldEntity;

            txtKullaniciAdi.Text = entity.Kod;
            txtAdi.Text = entity.Adi;
            txtSoyadi.Text = entity.Soyadi;
            txtEmail.Text = entity.Email;
            txtRol.Id = entity.RolId;
            txtRol.Text = entity.RolAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;

        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Kullanici
            {
                Id = Id,
                Kod = txtKullaniciAdi.Text,
                Adi = txtAdi.Text,
                Soyadi = txtSoyadi.Text,
                Email = txtEmail.Text,
                Sifre = _sifre,
                GizliKelime = _gizliKelime,
                RolId = (long)txtRol.Id,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();

        }

        protected override bool EntityInsert()
        {
            SifreUret();
            var result = base.EntityInsert();

            if (result)
                txtKullaniciAdi.Text.SifreMailiGonder(txtRol.Text, txtEmail.Text, _secureSifre, _secureGizliKelime);
          
            return result;
        }

        protected override bool EntityUpdate()
        {
            var result = base.EntityUpdate();

            if (_tekrarGonder)
                txtKullaniciAdi.Text.SifreMailiGonder(txtRol.Text, txtEmail.Text, _secureSifre, _secureGizliKelime);

            return result;

        }
        private void SifreUret()
        {
            var result = Functions.GeneralFunctions.SifreUret();

            _sifre = result.sifre;
            _gizliKelime = result.gizliKelime;
            _secureSifre = result.secureSifre;
            _secureGizliKelime = result.secureGizliKelime;

            GuncelNesneOlustur();
        }

        protected override void SifreSifirla()
        {
            if (Messages.EmailGonderimOnayi() != DialogResult.Yes) return;
            _tekrarGonder = true;
            SifreUret();
            btnKaydet.PerformClick();
        }

        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new Functions.SelectFunctions())
            {
                if (sender == txtRol)
                    sec.Sec(txtRol);
            }
        }
    }
}