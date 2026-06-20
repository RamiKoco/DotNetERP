namespace DotNet.ERP.UI.Win.UserControls.UserControl.EklerEditFormTable
{
    partial class EklerTable
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
            this.colBelgeAdi = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            this.repositoryBelge = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colDosyaUzantisi = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            this.colDosyaBoyutu = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            this.colEkleyenKullaniciAdi = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            this.colEklemeTarihi = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            this.repositoryTarih = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colAciklama = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryBelge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTarih.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MainView = this.tablo;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryBelge,
            this.repositoryTarih});
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
            this.colBelgeAdi,
            this.colDosyaUzantisi,
            this.colDosyaBoyutu,
            this.colEkleyenKullaniciAdi,
            this.colEklemeTarihi,
            this.colAciklama});
            this.tablo.GridControl = this.grid;
            this.tablo.Name = "tablo";
            this.tablo.OptionsCustomization.AllowColumnMoving = false;
            this.tablo.OptionsMenu.EnableColumnMenu = false;
            this.tablo.OptionsMenu.EnableFooterMenu = false;
            this.tablo.OptionsMenu.EnableGroupPanelMenu = false;
            this.tablo.OptionsNavigation.EnterMoveNextColumn = true;
            this.tablo.OptionsPrint.AutoWidth = false;
            this.tablo.OptionsPrint.PrintFooter = false;
            this.tablo.OptionsPrint.PrintGroupFooter = false;
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
            this.colBaslik.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colBaslik.OptionsFilter.AllowAutoFilter = false;
            this.colBaslik.StatusBarAciklama = "Bu dosyanın içeriğini kısa ve anlamlı şekilde tanımlayın.";
            this.colBaslik.StatusBarKisaYol = "";
            this.colBaslik.StatusBarKisaYolAciklama = "";
            this.colBaslik.Visible = true;
            this.colBaslik.VisibleIndex = 0;
            this.colBaslik.Width = 120;
            // 
            // colDosyaAdi
            // 
            this.colDosyaAdi.Caption = "Orijinal Dosya Adı";
            this.colDosyaAdi.FieldName = "DosyaAdi";
            this.colDosyaAdi.Name = "colDosyaAdi";
            this.colDosyaAdi.OptionsColumn.AllowEdit = false;
            this.colDosyaAdi.OptionsColumn.AllowMove = false;
            this.colDosyaAdi.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colDosyaAdi.StatusBarAciklama = "Belge No Giriniz.";
            this.colDosyaAdi.StatusBarKisaYol = null;
            this.colDosyaAdi.StatusBarKisaYolAciklama = null;
            this.colDosyaAdi.Visible = true;
            this.colDosyaAdi.VisibleIndex = 1;
            this.colDosyaAdi.Width = 120;
            // 
            // colBelgeAdi
            // 
            this.colBelgeAdi.Caption = "Belge Türü";
            this.colBelgeAdi.ColumnEdit = this.repositoryBelge;
            this.colBelgeAdi.FieldName = "BelgeAdi";
            this.colBelgeAdi.Name = "colBelgeAdi";
            this.colBelgeAdi.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colBelgeAdi.StatusBarAciklama = "Dosyanın hangi belge türüne ait olduğunu seçin.";
            this.colBelgeAdi.StatusBarKisaYol = "F4:";
            this.colBelgeAdi.StatusBarKisaYolAciklama = "Seçim Yap";
            this.colBelgeAdi.Visible = true;
            this.colBelgeAdi.VisibleIndex = 2;
            this.colBelgeAdi.Width = 120;
            // 
            // repositoryBelge
            // 
            this.repositoryBelge.AutoHeight = false;
            this.repositoryBelge.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryBelge.DisplayFormat.FormatString = "g";
            this.repositoryBelge.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryBelge.Name = "repositoryBelge";
            this.repositoryBelge.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.repositoryBelge.UseMaskAsDisplayFormat = true;
            // 
            // colDosyaUzantisi
            // 
            this.colDosyaUzantisi.AppearanceCell.Options.UseTextOptions = true;
            this.colDosyaUzantisi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDosyaUzantisi.Caption = "Dosya Uzantısı";
            this.colDosyaUzantisi.FieldName = "DosyaUzantisi";
            this.colDosyaUzantisi.Name = "colDosyaUzantisi";
            this.colDosyaUzantisi.OptionsColumn.AllowEdit = false;
            this.colDosyaUzantisi.OptionsColumn.AllowMove = false;
            this.colDosyaUzantisi.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colDosyaUzantisi.StatusBarAciklama = null;
            this.colDosyaUzantisi.StatusBarKisaYol = null;
            this.colDosyaUzantisi.StatusBarKisaYolAciklama = null;
            this.colDosyaUzantisi.Visible = true;
            this.colDosyaUzantisi.VisibleIndex = 3;
            this.colDosyaUzantisi.Width = 100;
            // 
            // colDosyaBoyutu
            // 
            this.colDosyaBoyutu.AppearanceCell.Options.UseTextOptions = true;
            this.colDosyaBoyutu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDosyaBoyutu.Caption = "Dosya Boyutu";
            this.colDosyaBoyutu.FieldName = "DosyaBoyutu";
            this.colDosyaBoyutu.Name = "colDosyaBoyutu";
            this.colDosyaBoyutu.OptionsColumn.AllowEdit = false;
            this.colDosyaBoyutu.OptionsColumn.AllowMove = false;
            this.colDosyaBoyutu.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colDosyaBoyutu.StatusBarAciklama = null;
            this.colDosyaBoyutu.StatusBarKisaYol = null;
            this.colDosyaBoyutu.StatusBarKisaYolAciklama = null;
            this.colDosyaBoyutu.Visible = true;
            this.colDosyaBoyutu.VisibleIndex = 4;
            this.colDosyaBoyutu.Width = 100;
            // 
            // colEkleyenKullaniciAdi
            // 
            this.colEkleyenKullaniciAdi.Caption = "Ekleyen";
            this.colEkleyenKullaniciAdi.FieldName = "EkleyenKullaniciAdi";
            this.colEkleyenKullaniciAdi.Name = "colEkleyenKullaniciAdi";
            this.colEkleyenKullaniciAdi.OptionsColumn.AllowEdit = false;
            this.colEkleyenKullaniciAdi.OptionsColumn.AllowMove = false;
            this.colEkleyenKullaniciAdi.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colEkleyenKullaniciAdi.StatusBarAciklama = null;
            this.colEkleyenKullaniciAdi.StatusBarKisaYol = null;
            this.colEkleyenKullaniciAdi.StatusBarKisaYolAciklama = null;
            this.colEkleyenKullaniciAdi.Visible = true;
            this.colEkleyenKullaniciAdi.VisibleIndex = 5;
            this.colEkleyenKullaniciAdi.Width = 120;
            // 
            // colEklemeTarihi
            // 
            this.colEklemeTarihi.AppearanceCell.Options.UseTextOptions = true;
            this.colEklemeTarihi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEklemeTarihi.Caption = "Ekleme Tarihi";
            this.colEklemeTarihi.ColumnEdit = this.repositoryTarih;
            this.colEklemeTarihi.DisplayFormat.FormatString = "g";
            this.colEklemeTarihi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEklemeTarihi.FieldName = "EklemeTarihi";
            this.colEklemeTarihi.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEklemeTarihi.Name = "colEklemeTarihi";
            this.colEklemeTarihi.OptionsColumn.AllowEdit = false;
            this.colEklemeTarihi.OptionsColumn.AllowMove = false;
            this.colEklemeTarihi.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colEklemeTarihi.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.True;
            this.colEklemeTarihi.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.colEklemeTarihi.StatusBarAciklama = "";
            this.colEklemeTarihi.StatusBarKisaYol = null;
            this.colEklemeTarihi.StatusBarKisaYolAciklama = null;
            this.colEklemeTarihi.UnboundDataType = typeof(System.DateTime);
            this.colEklemeTarihi.Visible = true;
            this.colEklemeTarihi.VisibleIndex = 6;
            this.colEklemeTarihi.Width = 130;
            // 
            // repositoryTarih
            // 
            this.repositoryTarih.AutoHeight = false;
            this.repositoryTarih.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryTarih.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryTarih.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.repositoryTarih.Name = "repositoryTarih";
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Açıklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colAciklama.OptionsColumn.FixedWidth = true;
            this.colAciklama.OptionsFilter.AllowAutoFilter = false;
            this.colAciklama.OptionsFilter.AllowFilter = false;
            this.colAciklama.StatusBarAciklama = "Dosya ile ilgili ek bilgi veya notlar girilebilir.";
            this.colAciklama.StatusBarKisaYol = null;
            this.colAciklama.StatusBarKisaYolAciklama = null;
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 7;
            this.colAciklama.Width = 250;
            // 
            // EklerTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grid);
            this.Name = "EklerTable";
            this.Controls.SetChildIndex(this.insUptNavigator, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryBelge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTarih.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTarih)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Grid.MyGridControl grid;
        private Grid.MyGridView tablo;
        private Grid.MyGridColumn colEklemeTarihi;
        private Grid.MyGridColumn colAciklama;
        private Grid.MyGridColumn colBelgeTuruId;
        private Grid.MyGridColumn colBaslik;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryBelge;
        private Grid.MyGridColumn colDosyaAdi;
        private Grid.MyGridColumn colDosyaUzantisi;
        private Grid.MyGridColumn colDosyaBoyutu;
        private Grid.MyGridColumn colEkleyenKullaniciAdi;
        private Grid.MyGridColumn colBelgeAdi;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryTarih;
    }
}