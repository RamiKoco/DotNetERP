using System.Windows.Forms;
using DotNet.ERP.Bll.Functions;
using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DevExpress.XtraBars;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.KullaniciForms
{
    public partial class SifremiUnuttumEditForm : BaseEditForm
    {
        #region Variables
        
        private readonly string _kullaniciAdi; 

        #endregion
        public SifremiUnuttumEditForm(params object[] prm)
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new KullaniciBll(myDataLayoutControl);
            HideItems = new BarItem[] { btnYeni, btnKaydet, btnGerial, btnSil };
            ShowItems = new BarItem[] { btnSifreSifirla };
            EventsLoad();

            _kullaniciAdi = prm[0].ToString();
        }

        public override void Yukle()
        {
            txtKullaniciAdi.Text = _kullaniciAdi;
        }

        protected override void SifreSifirla()
        {
            if (Messages.EmailGonderimOnayi() != DialogResult.Yes) return;

            var entity = ((KullaniciBll)Bll).SingleDetail(x => x.Kod == txtKullaniciAdi.Text)
                .EntityConvert<KullaniciS>();
            if (entity == null)
            {
                Messages.HataMesaji("Veritabanında Kayıtlı Böyle Bir Kullanıcı Bulunmamaktadır.");
                return;
            }

            if (txtAdi.Text == entity.Adi && txtSoyadi.Text == entity.Soyadi && txtEmail.Text == entity.Email && txtGizliKelime.Text.Md5Sifrele() == entity.GizliKelime)
            {

                var result = Functions.GeneralFunctions.SifreUret();

                var currentEntity = new Kullanici
                {
                    Id = entity.Id,
                    Kod = entity.Kod,
                    Adi = entity.Adi,
                    Soyadi = entity.Soyadi,
                    Email = entity.Email,
                    RolId = entity.RolId,
                    Aciklama = entity.Aciklama,
                    Durum = entity.Durum,
                    Sifre = result.sifre,
                    GizliKelime = result.gizliKelime
                };

                if (!((KullaniciBll)Bll).Update(entity, currentEntity)) return;
                var sonuc = txtKullaniciAdi.Text.SifreMailiGonder(entity.RolAdi, entity.Email,
                    result.secureSifre, result.secureGizliKelime);

                if (sonuc)
                {
                    Messages.BilgiMesaji("Şifre Sıfırlama İşlemi Başarılı Bir Şekilde Gerçekleşti");
                    Close();
                }
                else
                    Messages.HataMesaji("Şifre Sıfırlama İşlemi Başarılı Bir Şekilde Gerçekleşti. Ancak E-Mail Gönderilemedi. Lütfen Tekrar Deneyiniz.");

            }
            else
                Messages.HataMesaji("Girilen Bilgiler Mevcut Bilgilerle Uyuşmuyor. Lütfen Kontrol Edip Tekrar Deneyiniz.");

        }
    }
}