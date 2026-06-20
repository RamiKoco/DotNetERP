namespace DotNet.ERP.UI.Win.Forms.KullaniciForms
{
    partial class SifremiUnuttumEditForm
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
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition4 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition5 = new DevExpress.XtraLayout.RowDefinition();
            this.myDataLayoutControl = new DotNet.ERP.UI.Win.UserControls.Controls.MyDataLayoutControl();
            this.txtAdi = new DotNet.ERP.UI.Win.UserControls.Controls.MyTextEdit();
            this.txtGizliKelime = new DotNet.ERP.UI.Win.UserControls.Controls.MyTextEdit();
            this.txtEmail = new DotNet.ERP.UI.Win.UserControls.Controls.MyEmailTextEdit();
            this.txtSoyadi = new DotNet.ERP.UI.Win.UserControls.Controls.MyTextEdit();
            this.txtKullaniciAdi = new DotNet.ERP.UI.Win.UserControls.Controls.MyTextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resimMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataLayoutControl)).BeginInit();
            this.myDataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGizliKelime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoyadi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
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
            this.ribbonControl.Size = new System.Drawing.Size(368, 109);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // myDataLayoutControl
            // 
            this.myDataLayoutControl.Controls.Add(this.txtAdi);
            this.myDataLayoutControl.Controls.Add(this.txtGizliKelime);
            this.myDataLayoutControl.Controls.Add(this.txtEmail);
            this.myDataLayoutControl.Controls.Add(this.txtSoyadi);
            this.myDataLayoutControl.Controls.Add(this.txtKullaniciAdi);
            this.myDataLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataLayoutControl.Location = new System.Drawing.Point(0, 109);
            this.myDataLayoutControl.Name = "myDataLayoutControl";
            this.myDataLayoutControl.OptionsFocus.EnableAutoTabOrder = false;
            this.myDataLayoutControl.Root = this.Root;
            this.myDataLayoutControl.Size = new System.Drawing.Size(368, 140);
            this.myDataLayoutControl.TabIndex = 0;
            this.myDataLayoutControl.Text = "myDataLayoutControl1";
            // 
            // txtAdi
            // 
            this.txtAdi.EnterMoveNextControl = true;
            this.txtAdi.Location = new System.Drawing.Point(79, 36);
            this.txtAdi.MenuManager = this.ribbonControl;
            this.txtAdi.Name = "txtAdi";
            this.txtAdi.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtAdi.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtAdi.Properties.MaxLength = 50;
            this.txtAdi.Size = new System.Drawing.Size(277, 20);
            this.txtAdi.StatusBarAciklama = "Kullanıcının Adını Giriniz.";
            this.txtAdi.StyleController = this.myDataLayoutControl;
            this.txtAdi.TabIndex = 1;
            // 
            // txtGizliKelime
            // 
            this.txtGizliKelime.EnterMoveNextControl = true;
            this.txtGizliKelime.Location = new System.Drawing.Point(79, 108);
            this.txtGizliKelime.MenuManager = this.ribbonControl;
            this.txtGizliKelime.Name = "txtGizliKelime";
            this.txtGizliKelime.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtGizliKelime.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtGizliKelime.Properties.MaxLength = 50;
            this.txtGizliKelime.Size = new System.Drawing.Size(277, 20);
            this.txtGizliKelime.StatusBarAciklama = "Gizli Kelimeyi Giriniz.";
            this.txtGizliKelime.StyleController = this.myDataLayoutControl;
            this.txtGizliKelime.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.EnterMoveNextControl = true;
            this.txtEmail.Location = new System.Drawing.Point(79, 84);
            this.txtEmail.MenuManager = this.ribbonControl;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtEmail.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtEmail.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Strong;
            this.txtEmail.Properties.Mask.EditMask = "((([0-9a-zA-Z_%-])+[.])+|([0-9a-zA-Z_%-])+)+@((([0-9a-zA-Z_-])+[.])+|([0-9a-zA-Z_" +
    "-])+)+";
            this.txtEmail.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtEmail.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.RegExpMaskManager));
            this.txtEmail.Properties.MaskSettings.Set("allowBlankInput", true);
            this.txtEmail.Properties.MaskSettings.Set("mask", "((([0-9a-zA-Z_%-])+[.])+|([0-9a-zA-Z_%-])+)+@((([0-9a-zA-Z_-])+[.])+|([0-9a-zA-Z_" +
        "-])+)+");
            this.txtEmail.Properties.MaskSettings.Set("isAutoComplete", true);
            this.txtEmail.Properties.MaskSettings.Set("isOptimistic", false);
            this.txtEmail.Properties.MaxLength = 50;
            this.txtEmail.Size = new System.Drawing.Size(277, 20);
            this.txtEmail.StatusBarAciklama = "E-Mail Adresi Giriniz.";
            this.txtEmail.StyleController = this.myDataLayoutControl;
            this.txtEmail.TabIndex = 3;
            // 
            // txtSoyadi
            // 
            this.txtSoyadi.EnterMoveNextControl = true;
            this.txtSoyadi.Location = new System.Drawing.Point(79, 60);
            this.txtSoyadi.MenuManager = this.ribbonControl;
            this.txtSoyadi.Name = "txtSoyadi";
            this.txtSoyadi.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtSoyadi.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtSoyadi.Properties.MaxLength = 50;
            this.txtSoyadi.Size = new System.Drawing.Size(277, 20);
            this.txtSoyadi.StatusBarAciklama = "Kullanıcının Soyadını Giriniz.";
            this.txtSoyadi.StyleController = this.myDataLayoutControl;
            this.txtSoyadi.TabIndex = 2;
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.EnterMoveNextControl = true;
            this.txtKullaniciAdi.Location = new System.Drawing.Point(79, 12);
            this.txtKullaniciAdi.MenuManager = this.ribbonControl;
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtKullaniciAdi.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtKullaniciAdi.Properties.MaxLength = 50;
            this.txtKullaniciAdi.Size = new System.Drawing.Size(277, 20);
            this.txtKullaniciAdi.StatusBarAciklama = "Kullanıcı Adı Giriniz.";
            this.txtKullaniciAdi.StyleController = this.myDataLayoutControl;
            this.txtKullaniciAdi.TabIndex = 0;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.Root.Name = "Root";
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition1.Width = 100D;
            this.Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1});
            rowDefinition1.Height = 24D;
            rowDefinition1.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition2.Height = 24D;
            rowDefinition2.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition3.Height = 24D;
            rowDefinition3.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition4.Height = 24D;
            rowDefinition4.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition5.Height = 24D;
            rowDefinition5.SizeType = System.Windows.Forms.SizeType.Absolute;
            this.Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1,
            rowDefinition2,
            rowDefinition3,
            rowDefinition4,
            rowDefinition5});
            this.Root.Size = new System.Drawing.Size(368, 140);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem3.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem3.Control = this.txtKullaniciAdi;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(348, 24);
            this.layoutControlItem3.Text = "Kullanıcı Adı";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(55, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem1.Control = this.txtSoyadi;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.OptionsTableLayoutItem.RowIndex = 2;
            this.layoutControlItem1.Size = new System.Drawing.Size(348, 24);
            this.layoutControlItem1.Text = "Soyadı";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(55, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem2.Control = this.txtEmail;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.OptionsTableLayoutItem.RowIndex = 3;
            this.layoutControlItem2.Size = new System.Drawing.Size(348, 24);
            this.layoutControlItem2.Text = "E-Mail";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(55, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem4.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem4.Control = this.txtGizliKelime;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.OptionsTableLayoutItem.RowIndex = 4;
            this.layoutControlItem4.Size = new System.Drawing.Size(348, 24);
            this.layoutControlItem4.Text = "Gizli Kelime";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(55, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem5.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem5.Control = this.txtAdi;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutControlItem5.Size = new System.Drawing.Size(348, 24);
            this.layoutControlItem5.Text = "Adı";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(55, 13);
            // 
            // SifremiUnuttumEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 273);
            this.Controls.Add(this.myDataLayoutControl);
            this.IconOptions.ShowIcon = false;
            this.MaximumSize = new System.Drawing.Size(370, 274);
            this.MinimumSize = new System.Drawing.Size(370, 274);
            this.Name = "SifremiUnuttumEditForm";
            this.Text = "Şifremi Unuttum";
            this.Controls.SetChildIndex(this.ribbonControl, 0);
            this.Controls.SetChildIndex(this.myDataLayoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resimMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataLayoutControl)).EndInit();
            this.myDataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGizliKelime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoyadi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl;
        private UserControls.Controls.MyTextEdit txtGizliKelime;
        private UserControls.Controls.MyEmailTextEdit txtEmail;
        private UserControls.Controls.MyTextEdit txtSoyadi;
        private UserControls.Controls.MyTextEdit txtKullaniciAdi;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private UserControls.Controls.MyTextEdit txtAdi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}