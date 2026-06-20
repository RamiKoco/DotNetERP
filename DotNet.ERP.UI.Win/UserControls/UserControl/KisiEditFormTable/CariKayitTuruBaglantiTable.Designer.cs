namespace DotNet.ERP.UI.Win.UserControls.UserControl.KisiEditFormTable
{
    partial class CariKayitTuruBaglantiTable
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
            this.grid = new DotNet.ERP.UI.Win.UserControls.Grid.MyBandedGridControl();
            this.tablo = new DotNet.ERP.UI.Win.UserControls.Grid.MyBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colKayitTuru = new DotNet.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.repositoryKayitTuru = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colKod = new DotNet.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colKayitHesabi = new DotNet.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.repositoryCariler = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colAnaKayitHesabi = new DotNet.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colPozisyonAdi = new DotNet.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.repositoryPozisyon = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colAciklama = new DotNet.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colKayitId = new DotNet.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colPozisyonId = new DotNet.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryKayitTuru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryCariler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryPozisyon)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MainView = this.tablo;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryCariler,
            this.repositoryPozisyon,
            this.repositoryKayitTuru});
            this.grid.Size = new System.Drawing.Size(706, 370);
            this.grid.TabIndex = 5;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tablo});
            // 
            // tablo
            // 
            this.tablo.Appearance.BandPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tablo.Appearance.BandPanel.ForeColor = System.Drawing.Color.DarkBlue;
            this.tablo.Appearance.BandPanel.Options.UseFont = true;
            this.tablo.Appearance.BandPanel.Options.UseForeColor = true;
            this.tablo.Appearance.BandPanel.Options.UseTextOptions = true;
            this.tablo.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
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
            this.tablo.BandPanelRowHeight = 40;
            this.tablo.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3});
            this.tablo.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colKod,
            this.colKayitId,
            this.colKayitHesabi,
            this.colAnaKayitHesabi,
            this.colPozisyonId,
            this.colPozisyonAdi,
            this.colAciklama,
            this.colKayitTuru});
            this.tablo.GridControl = this.grid;
            this.tablo.Name = "tablo";
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
            this.tablo.OptionsView.ShowAutoFilterRow = true;
            this.tablo.OptionsView.ShowGroupPanel = false;
            this.tablo.OptionsView.ShowViewCaption = true;
            this.tablo.StatusBarAciklama = "Bağlantı Giriniz.";
            this.tablo.StatusBarKisaYol = "Shift+Insert :";
            this.tablo.StatusBarKisaYolAciklama = "Yeni Bağlantı.";
            this.tablo.ViewCaption = "Bağlantılar";
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Kayıt Hesabı Bilgileri";
            this.gridBand1.Columns.Add(this.colKayitTuru);
            this.gridBand1.Columns.Add(this.colKod);
            this.gridBand1.Columns.Add(this.colKayitHesabi);
            this.gridBand1.Columns.Add(this.colAnaKayitHesabi);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 417;
            // 
            // colKayitTuru
            // 
            this.colKayitTuru.Caption = "Kayıt Türü";
            this.colKayitTuru.ColumnEdit = this.repositoryKayitTuru;
            this.colKayitTuru.FieldName = "KayitTuru";
            this.colKayitTuru.Name = "colKayitTuru";
            this.colKayitTuru.StatusBarAciklama = "Kayıt Türü Seçiniz.";
            this.colKayitTuru.StatusBarKisaYol = "F4 :";
            this.colKayitTuru.StatusBarKisaYolAciklama = "Seçim Yap.";
            this.colKayitTuru.Visible = true;
            this.colKayitTuru.Width = 97;
            // 
            // repositoryKayitTuru
            // 
            this.repositoryKayitTuru.AutoHeight = false;
            this.repositoryKayitTuru.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryKayitTuru.Name = "repositoryKayitTuru";
            // 
            // colKod
            // 
            this.colKod.Caption = "Kod";
            this.colKod.FieldName = "Kod";
            this.colKod.Name = "colKod";
            this.colKod.OptionsColumn.AllowEdit = false;
            this.colKod.StatusBarAciklama = "";
            this.colKod.StatusBarKisaYol = null;
            this.colKod.StatusBarKisaYolAciklama = null;
            this.colKod.Visible = true;
            this.colKod.Width = 130;
            // 
            // colKayitHesabi
            // 
            this.colKayitHesabi.Caption = "Kayıt Hesabı";
            this.colKayitHesabi.ColumnEdit = this.repositoryCariler;
            this.colKayitHesabi.FieldName = "KayitHesabi";
            this.colKayitHesabi.Name = "colKayitHesabi";
            this.colKayitHesabi.StatusBarAciklama = "Kayıt Hesabı Seçiniz.";
            this.colKayitHesabi.StatusBarKisaYol = "F4: ";
            this.colKayitHesabi.StatusBarKisaYolAciklama = "Seçim Yap.";
            this.colKayitHesabi.Visible = true;
            this.colKayitHesabi.Width = 190;
            // 
            // repositoryCariler
            // 
            this.repositoryCariler.AutoHeight = false;
            this.repositoryCariler.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryCariler.Name = "repositoryCariler";
            this.repositoryCariler.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // colAnaKayitHesabi
            // 
            this.colAnaKayitHesabi.Caption = "Ana Kayıt Hesabı";
            this.colAnaKayitHesabi.FieldName = "AnaKayitHesabi";
            this.colAnaKayitHesabi.Name = "colAnaKayitHesabi";
            this.colAnaKayitHesabi.OptionsColumn.AllowEdit = false;
            this.colAnaKayitHesabi.OptionsColumn.ShowInCustomizationForm = false;
            this.colAnaKayitHesabi.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colAnaKayitHesabi.OptionsEditForm.VisibleIndex = -1;
            this.colAnaKayitHesabi.StatusBarAciklama = null;
            this.colAnaKayitHesabi.StatusBarKisaYol = null;
            this.colAnaKayitHesabi.StatusBarKisaYolAciklama = null;
            this.colAnaKayitHesabi.Width = 190;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "Pozisyon Bilgileri";
            this.gridBand2.Columns.Add(this.colPozisyonAdi);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 190;
            // 
            // colPozisyonAdi
            // 
            this.colPozisyonAdi.Caption = "Pozisyon";
            this.colPozisyonAdi.ColumnEdit = this.repositoryPozisyon;
            this.colPozisyonAdi.FieldName = "PozisyonAdi";
            this.colPozisyonAdi.Name = "colPozisyonAdi";
            this.colPozisyonAdi.StatusBarAciklama = "Pozisyon Seçiniz.";
            this.colPozisyonAdi.StatusBarKisaYol = "F4: ";
            this.colPozisyonAdi.StatusBarKisaYolAciklama = "Seçim Yap.";
            this.colPozisyonAdi.Visible = true;
            this.colPozisyonAdi.Width = 190;
            // 
            // repositoryPozisyon
            // 
            this.repositoryPozisyon.AutoHeight = false;
            this.repositoryPozisyon.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryPozisyon.Name = "repositoryPozisyon";
            this.repositoryPozisyon.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "Açıklama";
            this.gridBand3.Columns.Add(this.colAciklama);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 2;
            this.gridBand3.Width = 300;
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Açıklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.StatusBarAciklama = "Açıklama Notu Girin.";
            this.colAciklama.StatusBarKisaYol = null;
            this.colAciklama.StatusBarKisaYolAciklama = "";
            this.colAciklama.Visible = true;
            this.colAciklama.Width = 300;
            // 
            // colKayitId
            // 
            this.colKayitId.Caption = "KayitId";
            this.colKayitId.FieldName = "KayitId";
            this.colKayitId.Name = "colKayitId";
            this.colKayitId.OptionsColumn.AllowEdit = false;
            this.colKayitId.StatusBarAciklama = null;
            this.colKayitId.StatusBarKisaYol = null;
            this.colKayitId.StatusBarKisaYolAciklama = null;
            this.colKayitId.Visible = true;
            // 
            // colPozisyonId
            // 
            this.colPozisyonId.Caption = "PozisyonId";
            this.colPozisyonId.FieldName = "PozisyonId";
            this.colPozisyonId.Name = "colPozisyonId";
            this.colPozisyonId.OptionsColumn.AllowEdit = false;
            this.colPozisyonId.StatusBarAciklama = null;
            this.colPozisyonId.StatusBarKisaYol = null;
            this.colPozisyonId.StatusBarKisaYolAciklama = null;
            this.colPozisyonId.Visible = true;
            // 
            // CariKayitTuruBaglantiTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grid);
            this.Name = "CariKayitTuruBaglantiTable";
            this.Controls.SetChildIndex(this.insUptNavigator, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryKayitTuru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryCariler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryPozisyon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            #endregion

            private Grid.MyBandedGridControl grid;
            private Grid.MyBandedGridView tablo;
            private Grid.MyBandedGridColumn colKod;
            private Grid.MyBandedGridColumn colKayitHesabi;
            private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryCariler;
            private Grid.MyBandedGridColumn colPozisyonAdi;
            private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryPozisyon;
            private Grid.MyBandedGridColumn colAciklama;
            private Grid.MyBandedGridColumn colKayitId;
            private Grid.MyBandedGridColumn colPozisyonId;
        private Grid.MyBandedGridColumn colKayitTuru;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryKayitTuru;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private Grid.MyBandedGridColumn colAnaKayitHesabi;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
    }
    }