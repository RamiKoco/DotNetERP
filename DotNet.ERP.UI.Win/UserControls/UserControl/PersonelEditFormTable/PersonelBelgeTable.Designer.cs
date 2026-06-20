namespace DotNet.ERP.UI.Win.UserControls.UserControl.PersonelEditFormTable
{
    partial class PersonelBelgeTable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grid = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridControl();
            this.tablo = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridView();
            this.colBelgeTuruId = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            this.colBelgeAdi = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            this.repositoryBelge = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colBelgeNo = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            this.colVerilisTarihi = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            this.repositoryTarih = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colGecerlilikTarihi = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            this.colKurumlarId = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            this.colKurumAdi = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            this.repositoryKurum = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colAciklama = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            this.repositoryHesapTuru = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryBelge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTarih.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryKurum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryHesapTuru)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MainView = this.tablo;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryTarih,
            this.repositoryKurum,
            this.repositoryHesapTuru,
            this.repositoryBelge});
            this.grid.Size = new System.Drawing.Size(706, 370);
            this.grid.TabIndex = 5;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tablo});
            // 
            // tablo
            // 
            this.tablo.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tablo.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Maroon;
            this.tablo.Appearance.FooterPanel.Options.UseFont = true;
            this.tablo.Appearance.FooterPanel.Options.UseForeColor = true;
            this.tablo.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Maroon;
            this.tablo.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.tablo.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.tablo.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablo.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Maroon;
            this.tablo.Appearance.ViewCaption.Options.UseForeColor = true;
            this.tablo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBelgeTuruId,
            this.colBelgeAdi,
            this.colBelgeNo,
            this.colVerilisTarihi,
            this.colGecerlilikTarihi,
            this.colKurumlarId,
            this.colKurumAdi,
            this.colAciklama});
            this.tablo.GridControl = this.grid;
            this.tablo.Name = "tablo";
            this.tablo.OptionsCustomization.AllowColumnMoving = false;
            this.tablo.OptionsCustomization.AllowSort = false;
            this.tablo.OptionsMenu.EnableColumnMenu = false;
            this.tablo.OptionsMenu.EnableFooterMenu = false;
            this.tablo.OptionsMenu.EnableGroupPanelMenu = false;
            this.tablo.OptionsNavigation.EnterMoveNextColumn = true;
            this.tablo.OptionsPrint.AutoWidth = false;
            this.tablo.OptionsPrint.PrintFooter = false;
            this.tablo.OptionsPrint.PrintGroupFooter = false;
            this.tablo.OptionsView.ColumnAutoWidth = false;
            this.tablo.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.tablo.OptionsView.RowAutoHeight = true;
            this.tablo.OptionsView.ShowGroupPanel = false;
            this.tablo.OptionsView.ShowViewCaption = true;
            this.tablo.StatusBarAciklama = null;
            this.tablo.StatusBarKisaYol = null;
            this.tablo.StatusBarKisaYolAciklama = null;
            this.tablo.ViewCaption = "Belgeler";
            // 
            // colBelgeTuruId
            // 
            this.colBelgeTuruId.Caption = "BelgeTuruId";
            this.colBelgeTuruId.FieldName = "BelgeTuruId";
            this.colBelgeTuruId.Name = "colBelgeTuruId";
            this.colBelgeTuruId.OptionsColumn.AllowEdit = false;
            this.colBelgeTuruId.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colBelgeTuruId.OptionsColumn.ShowInCustomizationForm = false;
            this.colBelgeTuruId.OptionsFilter.AllowAutoFilter = false;
            this.colBelgeTuruId.OptionsFilter.AllowFilter = false;
            this.colBelgeTuruId.StatusBarAciklama = null;
            this.colBelgeTuruId.StatusBarKisaYol = null;
            this.colBelgeTuruId.StatusBarKisaYolAciklama = null;
            // 
            // colBelgeAdi
            // 
            this.colBelgeAdi.Caption = "Belge Türü";
            this.colBelgeAdi.ColumnEdit = this.repositoryBelge;
            this.colBelgeAdi.FieldName = "BelgeAdi";
            this.colBelgeAdi.Name = "colBelgeAdi";
            this.colBelgeAdi.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colBelgeAdi.OptionsFilter.AllowAutoFilter = false;
            this.colBelgeAdi.OptionsFilter.AllowFilter = false;
            this.colBelgeAdi.StatusBarAciklama = "Belge Türü Giriniz.";
            this.colBelgeAdi.StatusBarKisaYol = "F4 :";
            this.colBelgeAdi.StatusBarKisaYolAciklama = "Seçim Yap";
            this.colBelgeAdi.Visible = true;
            this.colBelgeAdi.VisibleIndex = 0;
            this.colBelgeAdi.Width = 100;
            // 
            // repositoryBelge
            // 
            this.repositoryBelge.AutoHeight = false;
            this.repositoryBelge.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryBelge.Name = "repositoryBelge";
            this.repositoryBelge.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // colBelgeNo
            // 
            this.colBelgeNo.Caption = "Belge No";
            this.colBelgeNo.FieldName = "BelgeNo";
            this.colBelgeNo.Name = "colBelgeNo";
            this.colBelgeNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colBelgeNo.OptionsFilter.AllowAutoFilter = false;
            this.colBelgeNo.OptionsFilter.AllowFilter = false;
            this.colBelgeNo.StatusBarAciklama = "Belge No Giriniz.";
            this.colBelgeNo.StatusBarKisaYol = null;
            this.colBelgeNo.StatusBarKisaYolAciklama = null;
            this.colBelgeNo.Visible = true;
            this.colBelgeNo.VisibleIndex = 1;
            this.colBelgeNo.Width = 90;
            // 
            // colVerilisTarihi
            // 
            this.colVerilisTarihi.AppearanceCell.Options.UseTextOptions = true;
            this.colVerilisTarihi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVerilisTarihi.Caption = "Veriliş Tarihi";
            this.colVerilisTarihi.ColumnEdit = this.repositoryTarih;
            this.colVerilisTarihi.FieldName = "VerilisTarihi";
            this.colVerilisTarihi.Name = "colVerilisTarihi";
            this.colVerilisTarihi.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colVerilisTarihi.OptionsFilter.AllowAutoFilter = false;
            this.colVerilisTarihi.OptionsFilter.AllowFilter = false;
            this.colVerilisTarihi.StatusBarAciklama = "Veriliş Tarihi Giriniz.";
            this.colVerilisTarihi.StatusBarKisaYol = null;
            this.colVerilisTarihi.StatusBarKisaYolAciklama = null;
            this.colVerilisTarihi.Visible = true;
            this.colVerilisTarihi.VisibleIndex = 2;
            this.colVerilisTarihi.Width = 90;
            // 
            // repositoryTarih
            // 
            this.repositoryTarih.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.repositoryTarih.AutoHeight = false;
            this.repositoryTarih.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryTarih.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryTarih.MaskSettings.Set("useAdvancingCaret", true);
            this.repositoryTarih.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.DateTimeMaskManager));
            this.repositoryTarih.Name = "repositoryTarih";
            // 
            // colGecerlilikTarihi
            // 
            this.colGecerlilikTarihi.AppearanceCell.Options.UseTextOptions = true;
            this.colGecerlilikTarihi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGecerlilikTarihi.Caption = "Geçerlilik Tarihi";
            this.colGecerlilikTarihi.ColumnEdit = this.repositoryTarih;
            this.colGecerlilikTarihi.FieldName = "GecerlilikTarihi";
            this.colGecerlilikTarihi.Name = "colGecerlilikTarihi";
            this.colGecerlilikTarihi.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colGecerlilikTarihi.OptionsFilter.AllowAutoFilter = false;
            this.colGecerlilikTarihi.OptionsFilter.AllowFilter = false;
            this.colGecerlilikTarihi.StatusBarAciklama = "Geçerlilik Tarihi Giriniz.";
            this.colGecerlilikTarihi.StatusBarKisaYol = null;
            this.colGecerlilikTarihi.StatusBarKisaYolAciklama = null;
            this.colGecerlilikTarihi.Visible = true;
            this.colGecerlilikTarihi.VisibleIndex = 3;
            this.colGecerlilikTarihi.Width = 90;
            // 
            // colKurumlarId
            // 
            this.colKurumlarId.Caption = "KurumlarId";
            this.colKurumlarId.FieldName = "KurumlarId";
            this.colKurumlarId.Name = "colKurumlarId";
            this.colKurumlarId.OptionsColumn.AllowEdit = false;
            this.colKurumlarId.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colKurumlarId.OptionsColumn.ShowInCustomizationForm = false;
            this.colKurumlarId.OptionsFilter.AllowAutoFilter = false;
            this.colKurumlarId.OptionsFilter.AllowFilter = false;
            this.colKurumlarId.StatusBarAciklama = null;
            this.colKurumlarId.StatusBarKisaYol = null;
            this.colKurumlarId.StatusBarKisaYolAciklama = null;
            // 
            // colKurumAdi
            // 
            this.colKurumAdi.Caption = "Kurum";
            this.colKurumAdi.ColumnEdit = this.repositoryKurum;
            this.colKurumAdi.FieldName = "KurumAdi";
            this.colKurumAdi.Name = "colKurumAdi";
            this.colKurumAdi.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colKurumAdi.OptionsFilter.AllowAutoFilter = false;
            this.colKurumAdi.OptionsFilter.AllowFilter = false;
            this.colKurumAdi.StatusBarAciklama = "Kurum Adı Seçiniz.";
            this.colKurumAdi.StatusBarKisaYol = "F4 :";
            this.colKurumAdi.StatusBarKisaYolAciklama = "Seçim Yap";
            this.colKurumAdi.Visible = true;
            this.colKurumAdi.VisibleIndex = 4;
            this.colKurumAdi.Width = 100;
            // 
            // repositoryKurum
            // 
            this.repositoryKurum.AutoHeight = false;
            this.repositoryKurum.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryKurum.Name = "repositoryKurum";
            this.repositoryKurum.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Açıklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colAciklama.OptionsFilter.AllowAutoFilter = false;
            this.colAciklama.OptionsFilter.AllowFilter = false;
            this.colAciklama.StatusBarAciklama = "Açıklama Giriniz";
            this.colAciklama.StatusBarKisaYol = null;
            this.colAciklama.StatusBarKisaYolAciklama = null;
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 5;
            this.colAciklama.Width = 200;
            // 
            // repositoryHesapTuru
            // 
            this.repositoryHesapTuru.AutoHeight = false;
            this.repositoryHesapTuru.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryHesapTuru.Name = "repositoryHesapTuru";
            // 
            // PersonelBelgeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grid);
            this.Name = "PersonelBelgeTable";
            this.Controls.SetChildIndex(this.insUptNavigator, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryBelge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTarih.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryKurum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryHesapTuru)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Grid.MyGridControl grid;
        private Grid.MyGridView tablo;
        private Grid.MyGridColumn colVerilisTarihi;
        private Grid.MyGridColumn colAciklama;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryTarih;
        private Grid.MyGridColumn colKurumlarId;
        private Grid.MyGridColumn colKurumAdi;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryHesapTuru;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryKurum;
        private Grid.MyGridColumn colBelgeTuruId;
        private Grid.MyGridColumn colBelgeAdi;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryBelge;
        private Grid.MyGridColumn colGecerlilikTarihi;
        private Grid.MyGridColumn colBelgeNo;
    }
}
