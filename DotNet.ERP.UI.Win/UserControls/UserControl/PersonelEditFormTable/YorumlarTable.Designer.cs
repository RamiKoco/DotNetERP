namespace DotNet.ERP.UI.Win.UserControls.UserControl.PersonelEditFormTable
{
    partial class YorumlarTable
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
            this.colTarih = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            this.repositoryTarih = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colYorum = new DotNet.ERP.UI.Win.UserControls.Grid.MyGridColumn();
            this.repositoryNot = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTarih.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryNot)).BeginInit();
            this.SuspendLayout();
            // 
            // insUptNavigator
            // 
            this.insUptNavigator.Location = new System.Drawing.Point(0, 372);
            this.insUptNavigator.Size = new System.Drawing.Size(774, 24);
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MainView = this.tablo;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryTarih,
            this.repositoryNot});
            this.grid.Size = new System.Drawing.Size(774, 372);
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
            this.colTarih,
            this.colYorum});
            this.tablo.GridControl = this.grid;
            this.tablo.Name = "tablo";
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
            this.tablo.StatusBarAciklama = "Bilgi Notu Giriniz.";
            this.tablo.StatusBarKisaYol = "Shift+Insert :";
            this.tablo.StatusBarKisaYolAciklama = "Not Girin";
            this.tablo.ViewCaption = "Yorumlar";
            // 
            // colTarih
            // 
            this.colTarih.AppearanceCell.Options.UseTextOptions = true;
            this.colTarih.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTarih.Caption = "Tarih";
            this.colTarih.ColumnEdit = this.repositoryTarih;
            this.colTarih.FieldName = "Tarih";
            this.colTarih.Name = "colTarih";
            this.colTarih.OptionsColumn.AllowEdit = false;
            this.colTarih.OptionsColumn.FixedWidth = true;
            this.colTarih.OptionsFilter.AllowAutoFilter = false;
            this.colTarih.OptionsFilter.AllowFilter = false;
            this.colTarih.StatusBarAciklama = "Tarih Seçiniz.";
            this.colTarih.StatusBarKisaYol = "F4 :";
            this.colTarih.StatusBarKisaYolAciklama = "Seçim Yap";
            this.colTarih.Visible = true;
            this.colTarih.VisibleIndex = 0;
            this.colTarih.Width = 120;
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
            this.repositoryTarih.Name = "repositoryTarih";
            // 
            // colYorum
            // 
            this.colYorum.Caption = "Yorum";
            this.colYorum.ColumnEdit = this.repositoryNot;
            this.colYorum.FieldName = "Yorum";
            this.colYorum.Name = "colYorum";
            this.colYorum.OptionsColumn.FixedWidth = true;
            this.colYorum.OptionsFilter.AllowAutoFilter = false;
            this.colYorum.OptionsFilter.AllowFilter = false;
            this.colYorum.StatusBarAciklama = "Yorum Giriniz.";
            this.colYorum.StatusBarKisaYol = null;
            this.colYorum.StatusBarKisaYolAciklama = null;
            this.colYorum.Visible = true;
            this.colYorum.VisibleIndex = 1;
            this.colYorum.Width = 629;
            // 
            // repositoryNot
            // 
            this.repositoryNot.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.repositoryNot.Name = "repositoryNot";
            this.repositoryNot.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            // 
            // YorumlarTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grid);
            this.Name = "YorumlarTable";
            this.Size = new System.Drawing.Size(774, 396);
            this.Controls.SetChildIndex(this.insUptNavigator, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTarih.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryNot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Grid.MyGridControl grid;
        private Grid.MyGridView tablo;
        private Grid.MyGridColumn colTarih;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryTarih;
        private Grid.MyGridColumn colYorum;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryNot;
    }
}
