using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Functions;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DevExpress.XtraBars;
using System.Configuration;
using System.Linq;
using DotNet.ERP.Bll.Functions;
using DevExpress.XtraEditors;
using System;

namespace DotNet.ERP.UI.Win.GenelForms
{
    public partial class BaglantiAyarlariEditForm : BaseEditForm
    {
        public BaglantiAyarlariEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            HideItems = new BarItem[] {btnYeni,btnSil };
            txtYetkilendirmeTuru.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<YetkilendirmeTuru>());
            EventsLoad();
        }

        public override void Yukle()
        {
            OldEntity = new BaglantiAyarlari
            {
                Server = ConfigurationManager.AppSettings["Server"],
                YetkilendirmeTuru = ConfigurationManager.AppSettings["YetkilendirmeTuru"].GetEnum<YetkilendirmeTuru>(),
                KullaniciAdi = ConfigurationManager.AppSettings["KullaniciAdi"].ConvertToSecureString(),
                Sifre = ConfigurationManager.AppSettings["YetkilendirmeTuru"].GetEnum<YetkilendirmeTuru>() == YetkilendirmeTuru.SqlServer ? "Burası Şifre Alanıdır".ConvertToSecureString() : "".ConvertToSecureString()

            };
            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            txtServer.Text = ConfigurationManager.AppSettings["Server"];
            txtYetkilendirmeTuru.SelectedItem = ConfigurationManager.AppSettings["YetkilendirmeTuru"];
            txtKullaniciAdi.Text = ConfigurationManager.AppSettings["KullaniciAdi"];
            txtSifre.Text =
                ConfigurationManager.AppSettings["YetkilendirmeTuru"].GetEnum<YetkilendirmeTuru>() ==
                YetkilendirmeTuru.SqlServer
                    ? "Burası Şifre Alanıdır"
                    : "";
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new BaglantiAyarlari
            {
                Server = txtServer.Text,
                YetkilendirmeTuru = txtYetkilendirmeTuru.Text.GetEnum<YetkilendirmeTuru>(),
                KullaniciAdi = txtKullaniciAdi.Text.ConvertToSecureString(),
                Sifre = txtSifre.Text.ConvertToSecureString()

            };

            ButonEnabledDurumu();
        }
        protected override bool EntityUpdate()
        {
            var list = ERP.Bll.Functions.GeneralFunctions.DegisenAlanlariGetir(OldEntity, CurrentEntity)
                .ToList();

            list.ForEach(x =>
            {
                switch (x)
                {
                    case "Server":
                        Forms.Functions.GeneralFunctions.AppSettingsWrite(x, txtServer.Text);
                        break;

                    case "YetkilendirmeTuru":
                        Forms.Functions.GeneralFunctions.AppSettingsWrite(x, txtYetkilendirmeTuru.Text);
                        break;

                    case "KullaniciAdi":
                        Forms.Functions.GeneralFunctions.AppSettingsWrite(x, txtKullaniciAdi.Text);
                        break;

                    case "Sifre":
                        Forms.Functions.GeneralFunctions.AppSettingsWrite(x, txtSifre.Text);
                        break;
                }
            });
            return true;
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