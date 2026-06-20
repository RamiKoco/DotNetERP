using System;
using System.Security;
using DotNet.ERP.Bll.Functions;
using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Functions;
using DotNet.ERP.Data.Contexts;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DevExpress.XtraEditors;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Yonetim.Forms.GenelForms
{
    public partial class KurumEditForm : BaseEditForm
    {
        #region Variables
        
        private readonly string _server;
        private readonly SecureString _kullaniciAdi;
        private readonly SecureString _sifre;
        private readonly YetkilendirmeTuru _yetkilendirmeTuru;

        #endregion
        public KurumEditForm(params object[] prm)
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new KurumBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Kurum;
            txtYetkilendirmeTuru.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<YetkilendirmeTuru>());
            EventsLoad();

            _server = prm[0].ToString();
            _kullaniciAdi = (SecureString)prm[1];
            _sifre = (SecureString)prm[2];
            _yetkilendirmeTuru = (YetkilendirmeTuru)prm[3];
            txtYetkilendirmeTuru.SelectedItem = _yetkilendirmeTuru.ToName();
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert
                ? new Kurum()
                : ((KurumBll)Bll).Single(Win.Forms.Functions.FilterFunctions.Filter<Kurum>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = "Yeni_Kurum";
            txtKod.Enabled = true;

        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Kurum)OldEntity;

            txtKod.Text = entity.Kod;
            txtKurumAdi.Text = entity.Ad;
            txtServer.Text = BaseIslemTuru == IslemTuru.EntityInsert ? _server : entity.Server;
            txtYetkilendirmeTuru.SelectedItem = txtYetkilendirmeTuru.Text.GetEnum<YetkilendirmeTuru>();
            txtKullaniciAdi.Text = BaseIslemTuru == IslemTuru.EntityInsert
                ? _kullaniciAdi.ConvertToUnSecureString()
                : entity.KullaniciAdi.Decrypt(entity.Id + entity.Kod);
            txtSifre.Text = BaseIslemTuru == IslemTuru.EntityInsert
                ? _sifre.ConvertToUnSecureString()
                : entity.Sifre.Decrypt(entity.Id + entity.Kod);


        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Kurum
            {
                Id = Id,
                Kod = txtKod.Text,
                Ad = txtKurumAdi.Text,
                Server = txtServer.Text,
                YetkilendirmeTuru = txtYetkilendirmeTuru.Text.GetEnum<YetkilendirmeTuru>(),
            };

            ((Kurum)CurrentEntity).KullaniciAdi = txtKullaniciAdi.Text.Encrypt(CurrentEntity.Id + CurrentEntity.Kod);
            ((Kurum)CurrentEntity).Sifre = txtSifre.Text.Encrypt(CurrentEntity.Id + CurrentEntity.Kod);

            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            if (!Win.Forms.Functions.GeneralFunctions.BaglantiKontrolu(txtServer.Text,
                    txtKullaniciAdi.Text.ConvertToSecureString(), txtSifre.Text.ConvertToSecureString(),
                    txtYetkilendirmeTuru.Text.GetEnum<YetkilendirmeTuru>())) return false;

            Win.Forms.Functions.GeneralFunctions.CreateConnectionString(txtKod.Text, txtServer.Text,
                txtKullaniciAdi.Text.ConvertToSecureString(), txtSifre.Text.ConvertToSecureString(),
                txtYetkilendirmeTuru.Text.GetEnum<YetkilendirmeTuru>());

            if (!Functions.GeneralFunctions.CreateDatabase<ERPContext>
                ("Lütfen Bekleyiniz.",
                    "Kurum Veritabanı Oluşturuluyor.",
                    "Kurum Veritabanı Oluşturulacaktır. Onaylıyor Musunuz?",
                    "Kurum Veritabanı Başarılı Bir Şekilde Oluşturuldu.")
               ) return false;

            Win.Forms.Functions.GeneralFunctions.CreateConnectionString("DotNet_ERP_Yonetim",
                txtServer.Text,
                txtKullaniciAdi.Text.ConvertToSecureString(),
                txtSifre.Text.ConvertToSecureString(),
                txtYetkilendirmeTuru.Text.GetEnum<YetkilendirmeTuru>());

            return base.EntityInsert();
        }

        protected override bool EntityUpdate()
        {
            if (!Win.Forms.Functions.GeneralFunctions.BaglantiKontrolu(txtServer.Text,
                    txtKullaniciAdi.Text.ConvertToSecureString(), txtSifre.Text.ConvertToSecureString(),
                    txtYetkilendirmeTuru.Text.GetEnum<YetkilendirmeTuru>())) return false;

            Win.Forms.Functions.GeneralFunctions.CreateConnectionString("DotNet_ERP_Yonetim",
                txtServer.Text,
                txtKullaniciAdi.Text.ConvertToSecureString(),
                txtSifre.Text.ConvertToSecureString(),
                txtYetkilendirmeTuru.Text.GetEnum<YetkilendirmeTuru>());
            return base.EntityUpdate();

        }

        protected override void Control_SelectedValueChanged(object sender, EventArgs e)
        {
           if (!(sender is ComboBoxEdit edit)) return;

           var yetkilendirmeTuru = edit.Text.GetEnum<YetkilendirmeTuru>();
           txtKullaniciAdi.Enabled = yetkilendirmeTuru == YetkilendirmeTuru.SqlServer;
           txtSifre.Enabled = yetkilendirmeTuru == YetkilendirmeTuru.SqlServer;
           txtKullaniciAdi.Focus();

           if (yetkilendirmeTuru != YetkilendirmeTuru.Windows) return;
           txtKullaniciAdi.Text = "";
           txtSifre.Text = "";
        }
    }
}