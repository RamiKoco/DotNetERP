using System.Windows.Forms;
using DotNet.ERP.Bll.Functions;
using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.GenelForms;
using DevExpress.XtraBars;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.KullaniciForms
{
    public partial class SifreDegistirEditForm : BaseEditForm
    {
        public SifreDegistirEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new KullaniciBll(myDataLayoutControl);
            HideItems = new BarItem[] { btnYeni, btnGerial, btnSil };
            EventsLoad();

        }

        private void SifreDegistir()
        {
            if (Messages.KayitMesaj() != DialogResult.Yes) return;

            var entity = ((KullaniciBll)Bll).SingleDetail(x => x.Id == AnaForm.KullaniciId).EntityConvert<Kullanici>();
            if (entity == null) return;

            if (HataliGiris()) return;

            if (entity.Sifre == txtEskiSifre.Text.Md5Sifrele())
            {
                var currentEntity = new Kullanici
                {
                    Id = entity.Id,
                    Kod = entity.Kod,
                    Adi = entity.Adi,
                    Soyadi = entity.Soyadi,
                    Email = entity.Email,
                    RolId = entity.RolId,
                    Sifre = txtYeniSifre.Text.Md5Sifrele(),
                    GizliKelime = string.IsNullOrEmpty(txtGizliKelime.Text) ? entity.GizliKelime : txtGizliKelime.Text.Md5Sifrele(),
                    Aciklama = entity.Aciklama,
                    Durum = entity.Durum
                };

                if (!((KullaniciBll)Bll).Update(entity, currentEntity)) return;
                Messages.BilgiMesaji("Şifreniz Başarılı Bir Şekilde Değiştirilmiştir.");
                Close();
            }
            else
            {
                Messages.HataMesaji("Girilen Eski Şifre Bilgisi Hatalıdır. Lütfen Kontrol Edip Tekrar Deneyiniz.");
                txtEskiSifre.Focus();
            }
        }

        private bool HataliGiris()
        {
            if (txtYeniSifre.Text != txtYeniSifre.Text)
            {
                Messages.HataMesaji("Girilen Yeni Şifre, Yeni Şifre Tekrarıyla Uyuşmuyor.");
                txtYeniSifre.Focus();
                return true;
            }

            if (txtYeniSifre.Text.Length < 8)
            {
                Messages.HataMesaji("Girilen Yeni Şifrenin Uzunluğu En Az 8 Karakter Olmalıdır");
                txtYeniSifre.Focus();
                return true;
            }

            if (!string.IsNullOrEmpty(txtGizliKelime.Text) && txtGizliKelime.Text.Length < 10)
            {
                Messages.HataMesaji("Girilen Gizli Kelimenin Uzunluğu En Az 10 Karakter Olmalıdır.");
                txtGizliKelime.Focus();
                return true;
            }

            return false;
        }

        protected override void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item == btnKaydet)
                SifreDegistir();

            else if(e.Item == btnCikis )
                Close();

        }

        protected override void BaseEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SablonKaydet();
        }
    }
}