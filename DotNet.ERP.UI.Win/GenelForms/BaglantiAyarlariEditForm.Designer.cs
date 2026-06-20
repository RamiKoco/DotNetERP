namespace DotNet.ERP.UI.Win.GenelForms
{
    partial class BaglantiAyarlariEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition2 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition4 = new DevExpress.XtraLayout.RowDefinition();
            this.myDataLayoutControl = new DotNet.ERP.UI.Win.UserControls.Controls.MyDataLayoutControl();
            this.txtSifre = new DotNet.ERP.UI.Win.UserControls.Controls.MyTextEdit();
            this.txtKullaniciAdi = new DotNet.ERP.UI.Win.UserControls.Controls.MyTextEdit();
            this.txtYetkilendirmeTuru = new DotNet.ERP.UI.Win.UserControls.Controls.MyComboBoxEdit();
            this.txtServer = new DotNet.ERP.UI.Win.UserControls.Controls.MyTextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resimMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataLayoutControl)).BeginInit();
            this.myDataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYetkilendirmeTuru.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            // 
            // 
            // 
            this.ribbonControl.SearchEditItem.AccessibleName = "Search Item";
            this.ribbonControl.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbonControl.SearchEditItem.EditWidth = 150;
            this.ribbonControl.SearchEditItem.Id = -5000;
            this.ribbonControl.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.Size = new System.Drawing.Size(358, 109);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // myDataLayoutControl
            // 
            this.myDataLayoutControl.Controls.Add(this.txtSifre);
            this.myDataLayoutControl.Controls.Add(this.txtKullaniciAdi);
            this.myDataLayoutControl.Controls.Add(this.txtYetkilendirmeTuru);
            this.myDataLayoutControl.Controls.Add(this.txtServer);
            this.myDataLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataLayoutControl.Location = new System.Drawing.Point(0, 109);
            this.myDataLayoutControl.Name = "myDataLayoutControl";
            this.myDataLayoutControl.OptionsFocus.EnableAutoTabOrder = false;
            this.myDataLayoutControl.Root = this.Root;
            this.myDataLayoutControl.Size = new System.Drawing.Size(358, 116);
            this.myDataLayoutControl.TabIndex = 0;
            this.myDataLayoutControl.Text = "myDataLayoutControl1";
            // 
            // txtSifre
            // 
            this.txtSifre.EnterMoveNextControl = true;
            this.txtSifre.Location = new System.Drawing.Point(112, 84);
            this.txtSifre.MenuManager = this.ribbonControl;
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtSifre.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtSifre.Properties.MaxLength = 50;
            this.txtSifre.Properties.UseSystemPasswordChar = true;
            this.txtSifre.Size = new System.Drawing.Size(156, 20);
            this.txtSifre.StatusBarAciklama = "Şifre Giriniz.";
            this.txtSifre.StyleController = this.myDataLayoutControl;
            this.txtSifre.TabIndex = 3;
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.EnterMoveNextControl = true;
            this.txtKullaniciAdi.Location = new System.Drawing.Point(112, 60);
            this.txtKullaniciAdi.MenuManager = this.ribbonControl;
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtKullaniciAdi.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtKullaniciAdi.Properties.MaxLength = 50;
            this.txtKullaniciAdi.Size = new System.Drawing.Size(156, 20);
            this.txtKullaniciAdi.StatusBarAciklama = "Kullanıcı Adı Giriniz.";
            this.txtKullaniciAdi.StyleController = this.myDataLayoutControl;
            this.txtKullaniciAdi.TabIndex = 2;
            // 
            // txtYetkilendirmeTuru
            // 
            this.txtYetkilendirmeTuru.EnterMoveNextControl = true;
            this.txtYetkilendirmeTuru.Location = new System.Drawing.Point(112, 36);
            this.txtYetkilendirmeTuru.MenuManager = this.ribbonControl;
            this.txtYetkilendirmeTuru.Name = "txtYetkilendirmeTuru";
            this.txtYetkilendirmeTuru.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtYetkilendirmeTuru.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtYetkilendirmeTuru.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtYetkilendirmeTuru.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtYetkilendirmeTuru.Size = new System.Drawing.Size(156, 20);
            this.txtYetkilendirmeTuru.StatusBarAciklama = "Yetkilendirme Türü Seçiniz.";
            this.txtYetkilendirmeTuru.StatusBarKisaYol = "F4 :";
            this.txtYetkilendirmeTuru.StatusBarKisaYolAciklama = "Seçim Yap";
            this.txtYetkilendirmeTuru.StyleController = this.myDataLayoutControl;
            this.txtYetkilendirmeTuru.TabIndex = 1;
            // 
            // txtServer
            // 
            this.txtServer.EnterMoveNextControl = true;
            this.txtServer.Location = new System.Drawing.Point(112, 12);
            this.txtServer.MenuManager = this.ribbonControl;
            this.txtServer.Name = "txtServer";
            this.txtServer.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtServer.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtServer.Properties.MaxLength = 50;
            this.txtServer.Size = new System.Drawing.Size(234, 20);
            this.txtServer.StatusBarAciklama = "Server Adı Giriniz.";
            this.txtServer.StyleController = this.myDataLayoutControl;
            this.txtServer.TabIndex = 0;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.Root.Name = "Root";
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition1.Width = 260D;
            columnDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition2.Width = 100D;
            this.Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1,
            columnDefinition2});
            rowDefinition1.Height = 24D;
            rowDefinition1.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition2.Height = 24D;
            rowDefinition2.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition3.Height = 24D;
            rowDefinition3.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition4.Height = 24D;
            rowDefinition4.SizeType = System.Windows.Forms.SizeType.Absolute;
            this.Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1,
            rowDefinition2,
            rowDefinition3,
            rowDefinition4});
            this.Root.Size = new System.Drawing.Size(358, 116);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem3.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem3.Control = this.txtServer;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.OptionsTableLayoutItem.ColumnSpan = 2;
            this.layoutControlItem3.Size = new System.Drawing.Size(338, 24);
            this.layoutControlItem3.Text = "Server";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(88, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem4.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem4.Control = this.txtYetkilendirmeTuru;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutControlItem4.Size = new System.Drawing.Size(260, 24);
            this.layoutControlItem4.Text = "Yetkilendirme Türü";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(88, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem5.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem5.Control = this.txtKullaniciAdi;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.OptionsTableLayoutItem.RowIndex = 2;
            this.layoutControlItem5.Size = new System.Drawing.Size(260, 24);
            this.layoutControlItem5.Text = "Kullanıcı Adı";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(88, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem6.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem6.Control = this.txtSifre;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.OptionsTableLayoutItem.RowIndex = 3;
            this.layoutControlItem6.Size = new System.Drawing.Size(260, 24);
            this.layoutControlItem6.Text = "Şifre";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(88, 13);
            // 
            // BaglantiAyarlariEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 249);
            this.Controls.Add(this.myDataLayoutControl);
            this.IconOptions.ShowIcon = false;
            this.MinimumSize = new System.Drawing.Size(360, 250);
            this.Name = "BaglantiAyarlariEditForm";
            this.Text = "Baglantı Ayarları";
            this.Controls.SetChildIndex(this.ribbonControl, 0);
            this.Controls.SetChildIndex(this.myDataLayoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resimMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataLayoutControl)).EndInit();
            this.myDataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYetkilendirmeTuru.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl;
        private UserControls.Controls.MyTextEdit txtSifre;
        private UserControls.Controls.MyTextEdit txtKullaniciAdi;
        private UserControls.Controls.MyComboBoxEdit txtYetkilendirmeTuru;
        private UserControls.Controls.MyTextEdit txtServer;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}