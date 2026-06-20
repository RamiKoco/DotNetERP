namespace DotNet.ERP.UI.Win.UserControls.UserControl.PersonelEditFormTable
{
    partial class PersonelEklerTable
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
            this.colBaslik = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            this.colDosyaAdi = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            this.colDosyaYolu = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            this.colDosyaUzantisi = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            this.colDosyaBoyutu = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            this.colEkleyenKullaniciAdi = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            this.colEklemeTarihi = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            this.repositoryTarih = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colAciklama = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            this.repositoryKurum = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryHesapTuru = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryBelge = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTarih.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryKurum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryHesapTuru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryBelge)).BeginInit();
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
            this.colBaslik,
            this.colDosyaAdi,
            this.colDosyaYolu,
            this.colDosyaUzantisi,
            this.colDosyaBoyutu,
            this.colEkleyenKullaniciAdi,
            this.colEklemeTarihi,
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
            this.tablo.ViewCaption = "Ekler";
            // 
            // colBelgeTuruId
            // 
            this.colBelgeTuruId.Caption = "BelgeTuruId";
            this.colBelgeTuruId.FieldName = "BelgeTuruId";
            this.colBelgeTuruId.Name = "colBelgeTuruId";
            this.colBelgeTuruId.OptionsColumn.AllowEdit = false;
            this.colBelgeTuruId.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colBelgeTuruId.OptionsColumn.FixedWidth = true;
            this.colBelgeTuruId.OptionsColumn.ShowInCustomizationForm = false;
            this.colBelgeTuruId.OptionsFilter.AllowAutoFilter = false;
            this.colBelgeTuruId.OptionsFilter.AllowFilter = false;
            this.colBelgeTuruId.StatusBarAciklama = null;
            this.colBelgeTuruId.StatusBarKisaYol = null;
            this.colBelgeTuruId.StatusBarKisaYolAciklama = null;
            // 
            // colBaslik
            // 
            this.colBaslik.Caption = "Başlık";
            this.colBaslik.FieldName = "Baslik";
            this.colBaslik.Name = "colBaslik";
            this.colBaslik.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colBaslik.OptionsFilter.AllowAutoFilter = false;
            this.colBaslik.OptionsFilter.AllowFilter = false;
            this.colBaslik.StatusBarAciklama = "Başlık Giriniz.";
            this.colBaslik.StatusBarKisaYol = "";
            this.colBaslik.StatusBarKisaYolAciklama = "";
            this.colBaslik.Visible = true;
            this.colBaslik.VisibleIndex = 0;
            this.colBaslik.Width = 100;
            // 
            // colDosyaAdi
            // 
            this.colDosyaAdi.Caption = "Orijinal Dosya Adı";
            this.colDosyaAdi.FieldName = "DosyaAdi";
            this.colDosyaAdi.Name = "colDosyaAdi";
            this.colDosyaAdi.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDosyaAdi.OptionsFilter.AllowAutoFilter = false;
            this.colDosyaAdi.OptionsFilter.AllowFilter = false;
            this.colDosyaAdi.StatusBarAciklama = "Belge No Giriniz.";
            this.colDosyaAdi.StatusBarKisaYol = null;
            this.colDosyaAdi.StatusBarKisaYolAciklama = null;
            this.colDosyaAdi.Visible = true;
            this.colDosyaAdi.VisibleIndex = 1;
            this.colDosyaAdi.Width = 90;
            // 
            // colDosyaYolu
            // 
            this.colDosyaYolu.Caption = "Dosya Yolu";
            this.colDosyaYolu.FieldName = "DosyaYolu";
            this.colDosyaYolu.Name = "colDosyaYolu";
            this.colDosyaYolu.OptionsColumn.AllowEdit = false;
            this.colDosyaYolu.StatusBarAciklama = null;
            this.colDosyaYolu.StatusBarKisaYol = null;
            this.colDosyaYolu.StatusBarKisaYolAciklama = null;
            this.colDosyaYolu.Visible = true;
            this.colDosyaYolu.VisibleIndex = 2;
            // 
            // colDosyaUzantisi
            // 
            this.colDosyaUzantisi.Caption = "Dosya Uzantısı";
            this.colDosyaUzantisi.FieldName = "DosyaUzantisi";
            this.colDosyaUzantisi.Name = "colDosyaUzantisi";
            this.colDosyaUzantisi.OptionsColumn.AllowEdit = false;
            this.colDosyaUzantisi.StatusBarAciklama = null;
            this.colDosyaUzantisi.StatusBarKisaYol = null;
            this.colDosyaUzantisi.StatusBarKisaYolAciklama = null;
            this.colDosyaUzantisi.Visible = true;
            this.colDosyaUzantisi.VisibleIndex = 3;
            // 
            // colDosyaBoyutu
            // 
            this.colDosyaBoyutu.Caption = "Dosya Boyutu";
            this.colDosyaBoyutu.FieldName = "DosyaBoyutu";
            this.colDosyaBoyutu.Name = "colDosyaBoyutu";
            this.colDosyaBoyutu.OptionsColumn.AllowEdit = false;
            this.colDosyaBoyutu.StatusBarAciklama = null;
            this.colDosyaBoyutu.StatusBarKisaYol = null;
            this.colDosyaBoyutu.StatusBarKisaYolAciklama = null;
            this.colDosyaBoyutu.Visible = true;
            this.colDosyaBoyutu.VisibleIndex = 6;
            // 
            // colEkleyenKullaniciAdi
            // 
            this.colEkleyenKullaniciAdi.Caption = "Ekleyen";
            this.colEkleyenKullaniciAdi.FieldName = "EkleyenKullaniciAdi";
            this.colEkleyenKullaniciAdi.Name = "colEkleyenKullaniciAdi";
            this.colEkleyenKullaniciAdi.OptionsColumn.AllowEdit = false;
            this.colEkleyenKullaniciAdi.StatusBarAciklama = null;
            this.colEkleyenKullaniciAdi.StatusBarKisaYol = null;
            this.colEkleyenKullaniciAdi.StatusBarKisaYolAciklama = null;
            this.colEkleyenKullaniciAdi.Visible = true;
            this.colEkleyenKullaniciAdi.VisibleIndex = 7;
            // 
            // colEklemeTarihi
            // 
            this.colEklemeTarihi.AppearanceCell.Options.UseTextOptions = true;
            this.colEklemeTarihi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEklemeTarihi.Caption = "Ekleme Tarihi";
            this.colEklemeTarihi.ColumnEdit = this.repositoryTarih;
            this.colEklemeTarihi.FieldName = "EklemeTarihi";
            this.colEklemeTarihi.Name = "colEklemeTarihi";
            this.colEklemeTarihi.OptionsColumn.AllowEdit = false;
            this.colEklemeTarihi.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colEklemeTarihi.OptionsFilter.AllowAutoFilter = false;
            this.colEklemeTarihi.OptionsFilter.AllowFilter = false;
            this.colEklemeTarihi.StatusBarAciklama = "";
            this.colEklemeTarihi.StatusBarKisaYol = null;
            this.colEklemeTarihi.StatusBarKisaYolAciklama = null;
            this.colEklemeTarihi.Visible = true;
            this.colEklemeTarihi.VisibleIndex = 4;
            this.colEklemeTarihi.Width = 90;
            // 
            // repositoryTarih
            // 
            this.repositoryTarih.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.repositoryTarih.AutoHeight = false;
            this.repositoryTarih.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryTarih.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryTarih.DisplayFormat.FormatString = "G";
            this.repositoryTarih.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryTarih.EditFormat.FormatString = "G";
            this.repositoryTarih.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryTarih.MaskSettings.Set("useAdvancingCaret", true);
            this.repositoryTarih.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.DateTimeMaskManager));
            this.repositoryTarih.MaskSettings.Set("mask", "G");
            this.repositoryTarih.Name = "repositoryTarih";
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
            // repositoryKurum
            // 
            this.repositoryKurum.AutoHeight = false;
            this.repositoryKurum.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryKurum.Name = "repositoryKurum";
            this.repositoryKurum.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // repositoryHesapTuru
            // 
            this.repositoryHesapTuru.AutoHeight = false;
            this.repositoryHesapTuru.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryHesapTuru.Name = "repositoryHesapTuru";
            // 
            // repositoryBelge
            // 
            this.repositoryBelge.AutoHeight = false;
            this.repositoryBelge.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryBelge.Name = "repositoryBelge";
            this.repositoryBelge.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // PersonelEklerTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grid);
            this.Name = "PersonelEklerTable";
            this.Controls.SetChildIndex(this.insUptNavigator, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTarih.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryKurum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryHesapTuru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryBelge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Grid.MyGridControl grid;
        private Grid.MyGridView tablo;
        private Grid.MyGridColumn colEklemeTarihi;
        private Grid.MyGridColumn colAciklama;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryTarih;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryHesapTuru;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryKurum;
        private Grid.MyGridColumn colBelgeTuruId;
        private Grid.MyGridColumn colBaslik;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryBelge;
        private Grid.MyGridColumn colDosyaAdi;
        private Grid.MyGridColumn colDosyaYolu;
        private Grid.MyGridColumn colDosyaUzantisi;
        private Grid.MyGridColumn colDosyaBoyutu;
        private Grid.MyGridColumn colEkleyenKullaniciAdi;
    }
}