namespace DotNet.ERP.UI.Win.GenelForms
{
    partial class KurumBilgileriEditForm
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
            DevExpress.XtraLayout.ColumnDefinition columnDefinition3 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition4 = new DevExpress.XtraLayout.RowDefinition();
            this.myDataLayoutControl = new DotNet.ERP.UI.Win.UserControls.Controls.MyDataLayoutControl();
            this.txtKurumAdi = new DotNet.ERP.UI.Win.UserControls.Controls.MyTextEdit();
            this.txtKod = new DotNet.ERP.UI.Win.UserControls.Controls.MyKodTextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtVergiDairesi = new DotNet.ERP.UI.Win.UserControls.Controls.MyButtonEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtVergiNo = new DotNet.ERP.UI.Win.UserControls.Controls.MyVergiNoTextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtIl = new DotNet.ERP.UI.Win.UserControls.Controls.MyButtonEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtIlce = new DotNet.ERP.UI.Win.UserControls.Controls.MyButtonEdit();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resimMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataLayoutControl)).BeginInit();
            this.myDataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKurumAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVergiDairesi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVergiNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIlce.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Size = new System.Drawing.Size(464, 109);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // myDataLayoutControl
            // 
            this.myDataLayoutControl.Controls.Add(this.txtIlce);
            this.myDataLayoutControl.Controls.Add(this.txtIl);
            this.myDataLayoutControl.Controls.Add(this.txtVergiNo);
            this.myDataLayoutControl.Controls.Add(this.txtVergiDairesi);
            this.myDataLayoutControl.Controls.Add(this.txtKurumAdi);
            this.myDataLayoutControl.Controls.Add(this.txtKod);
            this.myDataLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataLayoutControl.Location = new System.Drawing.Point(0, 109);
            this.myDataLayoutControl.Name = "myDataLayoutControl";
            this.myDataLayoutControl.OptionsFocus.EnableAutoTabOrder = false;
            this.myDataLayoutControl.Root = this.Root;
            this.myDataLayoutControl.Size = new System.Drawing.Size(464, 119);
            this.myDataLayoutControl.TabIndex = 0;
            this.myDataLayoutControl.Text = "myDataLayoutControl1";
            // 
            // txtKurumAdi
            // 
            this.txtKurumAdi.EnterMoveNextControl = true;
            this.txtKurumAdi.Location = new System.Drawing.Point(77, 36);
            this.txtKurumAdi.MenuManager = this.ribbonControl;
            this.txtKurumAdi.Name = "txtKurumAdi";
            this.txtKurumAdi.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtKurumAdi.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtKurumAdi.Properties.MaxLength = 50;
            this.txtKurumAdi.Size = new System.Drawing.Size(375, 20);
            this.txtKurumAdi.StatusBarAciklama = "Kurum Adı Giriniz.";
            this.txtKurumAdi.StyleController = this.myDataLayoutControl;
            this.txtKurumAdi.TabIndex = 0;
            // 
            // txtKod
            // 
            this.txtKod.EnterMoveNextControl = true;
            this.txtKod.Location = new System.Drawing.Point(77, 12);
            this.txtKod.MenuManager = this.ribbonControl;
            this.txtKod.Name = "txtKod";
            this.txtKod.Properties.Appearance.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtKod.Properties.Appearance.Options.UseBackColor = true;
            this.txtKod.Properties.Appearance.Options.UseTextOptions = true;
            this.txtKod.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtKod.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtKod.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtKod.Properties.MaxLength = 20;
            this.txtKod.Size = new System.Drawing.Size(143, 20);
            this.txtKod.StatusBarAciklama = "Kod Giriniz";
            this.txtKod.StyleController = this.myDataLayoutControl;
            this.txtKod.TabIndex = 5;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem1});
            this.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.Root.Name = "Root";
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition1.Width = 212D;
            columnDefinition2.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition2.Width = 20D;
            columnDefinition3.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition3.Width = 212D;
            this.Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1,
            columnDefinition2,
            columnDefinition3});
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
            this.Root.Size = new System.Drawing.Size(464, 119);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem2.Control = this.txtKurumAdi;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.OptionsTableLayoutItem.ColumnSpan = 3;
            this.layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutControlItem2.Size = new System.Drawing.Size(444, 24);
            this.layoutControlItem2.Text = "Kurum Adı";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 13);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // txtVergiDairesi
            // 
            this.txtVergiDairesi.EnterMoveNextControl = true;
            this.txtVergiDairesi.Id = null;
            this.txtVergiDairesi.Location = new System.Drawing.Point(77, 60);
            this.txtVergiDairesi.MenuManager = this.ribbonControl;
            this.txtVergiDairesi.Name = "txtVergiDairesi";
            this.txtVergiDairesi.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtVergiDairesi.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtVergiDairesi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtVergiDairesi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtVergiDairesi.Size = new System.Drawing.Size(143, 20);
            this.txtVergiDairesi.StatusBarAciklama = "Kurumun bağlı olduğu vergi dairesini seçiniz.";
            this.txtVergiDairesi.StatusBarKisaYol = "F4 :";
            this.txtVergiDairesi.StatusBarKisaYolAciklama = "Seçim Yap";
            this.txtVergiDairesi.StyleController = this.myDataLayoutControl;
            this.txtVergiDairesi.TabIndex = 1;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem3.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem3.Control = this.txtVergiDairesi;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.OptionsTableLayoutItem.RowIndex = 2;
            this.layoutControlItem3.Size = new System.Drawing.Size(212, 24);
            this.layoutControlItem3.Text = "Vergi Dairesi";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(60, 20);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // txtVergiNo
            // 
            this.txtVergiNo.EnterMoveNextControl = true;
            this.txtVergiNo.Location = new System.Drawing.Point(309, 60);
            this.txtVergiNo.MenuManager = this.ribbonControl;
            this.txtVergiNo.Name = "txtVergiNo";
            this.txtVergiNo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtVergiNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtVergiNo.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtVergiNo.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtVergiNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtVergiNo.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.RegExpMaskManager));
            this.txtVergiNo.Properties.MaskSettings.Set("allowBlankInput", true);
            this.txtVergiNo.Properties.MaskSettings.Set("mask", "\\d{10}");
            this.txtVergiNo.Properties.MaskSettings.Set("isAutoComplete", false);
            this.txtVergiNo.Properties.MaskSettings.Set("isOptimistic", false);
            this.txtVergiNo.Properties.MaskSettings.Set("placeholder", ' ');
            this.txtVergiNo.Properties.MaxLength = 50;
            this.txtVergiNo.Size = new System.Drawing.Size(143, 20);
            this.txtVergiNo.StatusBarAciklama = "Vergi No Giriniz. Örn: 12345678912";
            this.txtVergiNo.StyleController = this.myDataLayoutControl;
            this.txtVergiNo.TabIndex = 3;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem4.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem4.Control = this.txtVergiNo;
            this.layoutControlItem4.Location = new System.Drawing.Point(232, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.OptionsTableLayoutItem.ColumnIndex = 2;
            this.layoutControlItem4.OptionsTableLayoutItem.RowIndex = 2;
            this.layoutControlItem4.Size = new System.Drawing.Size(212, 24);
            this.layoutControlItem4.Text = "Vergi No";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(60, 20);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // txtIl
            // 
            this.txtIl.EnterMoveNextControl = true;
            this.txtIl.Id = null;
            this.txtIl.Location = new System.Drawing.Point(77, 84);
            this.txtIl.MenuManager = this.ribbonControl;
            this.txtIl.Name = "txtIl";
            this.txtIl.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtIl.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtIl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtIl.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtIl.Size = new System.Drawing.Size(143, 20);
            this.txtIl.StatusBarAciklama = "Bu adresin bulunduğu şehri belirtin.";
            this.txtIl.StatusBarKisaYol = "F4 :";
            this.txtIl.StatusBarKisaYolAciklama = "Seçim Yap";
            this.txtIl.StyleController = this.myDataLayoutControl;
            this.txtIl.TabIndex = 2;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem5.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem5.Control = this.txtIl;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.OptionsTableLayoutItem.RowIndex = 3;
            this.layoutControlItem5.Size = new System.Drawing.Size(212, 27);
            this.layoutControlItem5.Text = "İl";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(60, 20);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // txtIlce
            // 
            this.txtIlce.EnterMoveNextControl = true;
            this.txtIlce.Id = null;
            this.txtIlce.Location = new System.Drawing.Point(309, 84);
            this.txtIlce.MenuManager = this.ribbonControl;
            this.txtIlce.Name = "txtIlce";
            this.txtIlce.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtIlce.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtIlce.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtIlce.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtIlce.Size = new System.Drawing.Size(143, 20);
            this.txtIlce.StatusBarAciklama = "Bu adresin bulunduğu şehri belirtin.";
            this.txtIlce.StatusBarKisaYol = "F4 :";
            this.txtIlce.StatusBarKisaYolAciklama = "İlçe Seç";
            this.txtIlce.StyleController = this.myDataLayoutControl;
            this.txtIlce.TabIndex = 4;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem6.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem6.Control = this.txtIlce;
            this.layoutControlItem6.Location = new System.Drawing.Point(232, 72);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.OptionsTableLayoutItem.ColumnIndex = 2;
            this.layoutControlItem6.OptionsTableLayoutItem.RowIndex = 3;
            this.layoutControlItem6.Size = new System.Drawing.Size(212, 27);
            this.layoutControlItem6.Text = "İlçe";
            this.layoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(60, 20);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem1.Control = this.txtKod;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(212, 24);
            this.layoutControlItem1.Text = "Kod";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 13);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // KurumBilgileriEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 252);
            this.Controls.Add(this.myDataLayoutControl);
            this.IconOptions.ShowIcon = false;
            this.MinimumSize = new System.Drawing.Size(466, 253);
            this.Name = "KurumBilgileriEditForm";
            this.Text = "Kurum Kartı";
            this.Controls.SetChildIndex(this.ribbonControl, 0);
            this.Controls.SetChildIndex(this.myDataLayoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resimMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataLayoutControl)).EndInit();
            this.myDataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtKurumAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVergiDairesi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVergiNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIlce.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private UserControls.Controls.MyTextEdit txtKurumAdi;
        private UserControls.Controls.MyKodTextEdit txtKod;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private UserControls.Controls.MyButtonEdit txtVergiDairesi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private UserControls.Controls.MyVergiNoTextEdit txtVergiNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private UserControls.Controls.MyButtonEdit txtIl;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private UserControls.Controls.MyButtonEdit txtIlce;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}