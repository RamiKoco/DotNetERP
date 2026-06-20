using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Functions;
using DotNet.ERP.Data.Contexts;
using DotNet.ERP.UI.Win.Show;
using DotNet.ERP.UI.Win.UserControls.Controls;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DotNet.ERP.Bll.Functions;

namespace DotNet.ERP.UI.Yonetim.Forms.GenelForms
{
    public partial class GirisForm : XtraForm
    {

        #region Variables

        private Point _mouseLocation; 
        
        #endregion
        public GirisForm()
        {
            InitializeComponent();
            txtYetkilendirme.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<YetkilendirmeTuru>());
            EventsLoad();
        }

        private void EventsLoad()
        {
            //Control Events
            foreach (Control control in Controls)
            {
                if (!(control is MyDataLayoutControl)) continue;
                control.MouseDown += Control_MouseDown;
                control.MouseMove += Control_MouseMove;

                foreach (Control ctrl in control.Controls)
                {
                    ctrl.KeyDown += Control_KeyDown;

                    switch (ctrl)
                    {
                        case MySimpleButton btn:
                            btn.Click += Control_Click;
                            break;

                        case MyComboBoxEdit edit:
                            edit.SelectedValueChanged += Control_SelectedValueChanged;
                            break;
                    }
                }
            }

            //Form Events
            Shown += GirisForm_Shown;
        }

        private void Yukle()
        {
            txtVersiyon.Text = $"Versiyon : {Assembly.GetExecutingAssembly().GetName().Version}";

            var connectionStringArray = Bll.Functions.GeneralFunctions.GetConnectionString().Split(';');
            var dictionary = new Dictionary<string, string>();

            connectionStringArray.ForEach(x =>
            {
                var row = x.Split('=');
                dictionary.Add(row[0], row[1]);
            });

            txtServer.Text = dictionary.GetValueOrDefault("Data Source", "");
            txtYetkilendirme.SelectedItem = dictionary.ContainsKey("Password")
                ? YetkilendirmeTuru.SqlServer.ToName()
                : YetkilendirmeTuru.Windows.ToName();

            if (txtYetkilendirme.Text.GetEnum<YetkilendirmeTuru>() == YetkilendirmeTuru.SqlServer)
                txtKullaniciAdi.Focus();
            else
                btnGiris.Focus();
        }

        private void Giris()
        {
            if (!Win.Forms.Functions.GeneralFunctions.BaglantiKontrolu(txtServer.Text,
                    txtKullaniciAdi.Text.ConvertToSecureString(), txtSifre.Text.ConvertToSecureString(),
                    txtYetkilendirme.Text.GetEnum<YetkilendirmeTuru>())) return;

            Win.Forms.Functions.GeneralFunctions.CreateConnectionString("DotNet_ERP_Yonetim", txtServer.Text,
                txtKullaniciAdi.Text.ConvertToSecureString(), txtSifre.Text.ConvertToSecureString(),
                txtYetkilendirme.Text.GetEnum<YetkilendirmeTuru>());

            if (!Functions.GeneralFunctions.CreateDatabase<ERPYonetimContext>
                ("Lütfen Bekleyiniz.",
                    "Program İlk Kurulum İçin Hazırlanıyor...",
                    "Program İlk Kurulum İşlemi Yapılacaktır. Onaylıyor Musunuz?",
                    "İlk Kurulum İşlemi Başarılı Bir Şekilde Tamamlandı.")
               ) return;

            Hide();

            ShowRibbonForms<AnaForm>.ShowForm(false, txtServer.Text, txtKullaniciAdi.Text.ConvertToSecureString(),
                txtSifre.Text.ConvertToSecureString(),txtYetkilendirme.Text.GetEnum<YetkilendirmeTuru>());
            txtKullaniciAdi.Text = "";
            txtSifre.Text = "";
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseLocation = new Point(-e.X, -e.Y);
        }
        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left) return;

            var position = MousePosition;
            position.Offset(_mouseLocation.X,_mouseLocation.Y);
            Location = position;
        }
        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                Close();

        }
        private void Control_Click(object sender, System.EventArgs e)
        {
            if (!(sender is MySimpleButton button)) return;

            if (button == btnGiris)
                Giris();
            else if (button == btnVazgec)
                Close();
        }

        private void Control_SelectedValueChanged(object sender, System.EventArgs e)
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

        private void GirisForm_Shown(object sender, System.EventArgs e)
        {
            Yukle();
        }
    }
}