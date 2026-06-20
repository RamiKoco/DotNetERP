namespace DotNet.ERP.UI.Win.Forms.CariForms.CariSubeForms
{
    partial class CariSubeBaglantiEditForm
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
            this.DataLayoutGenel = new DotNet.ERP.UI.Win.UserControls.Controls.MyDataLayoutControl();
            this.tabUst = new DevExpress.XtraBars.Navigation.TabPane();
            this.pageIletisimBilgileri = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resimMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataLayoutGenel)).BeginInit();
            this.DataLayoutGenel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabUst)).BeginInit();
            this.tabUst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Size = new System.Drawing.Size(948, 109);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // DataLayoutGenel
            // 
            this.DataLayoutGenel.Controls.Add(this.tabUst);
            this.DataLayoutGenel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataLayoutGenel.Location = new System.Drawing.Point(0, 109);
            this.DataLayoutGenel.Name = "DataLayoutGenel";
            this.DataLayoutGenel.OptionsFocus.EnableAutoTabOrder = false;
            this.DataLayoutGenel.Root = this.Root;
            this.DataLayoutGenel.Size = new System.Drawing.Size(948, 316);
            this.DataLayoutGenel.TabIndex = 0;
            this.DataLayoutGenel.Text = "myDataLayoutControl1";
            // 
            // tabUst
            // 
            this.tabUst.AppearanceButton.Hovered.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.tabUst.AppearanceButton.Hovered.ForeColor = System.Drawing.Color.DarkBlue;
            this.tabUst.AppearanceButton.Hovered.Options.UseFont = true;
            this.tabUst.AppearanceButton.Hovered.Options.UseForeColor = true;
            this.tabUst.AppearanceButton.Normal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.tabUst.AppearanceButton.Normal.Options.UseFont = true;
            this.tabUst.AppearanceButton.Pressed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.tabUst.AppearanceButton.Pressed.ForeColor = System.Drawing.Color.DarkGreen;
            this.tabUst.AppearanceButton.Pressed.Options.UseFont = true;
            this.tabUst.AppearanceButton.Pressed.Options.UseForeColor = true;
            this.tabUst.Controls.Add(this.pageIletisimBilgileri);
            this.tabUst.Location = new System.Drawing.Point(12, 12);
            this.tabUst.Name = "tabUst";
            this.tabUst.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabUst.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.pageIletisimBilgileri});
            this.tabUst.RegularSize = new System.Drawing.Size(924, 292);
            this.tabUst.SelectedPage = this.pageIletisimBilgileri;
            this.tabUst.Size = new System.Drawing.Size(924, 292);
            this.tabUst.TabIndex = 0;
            this.tabUst.Text = "tabPane1";
            // 
            // pageIletisimBilgileri
            // 
            this.pageIletisimBilgileri.BackgroundPadding = new System.Windows.Forms.Padding(0, -5, 0, 0);
            this.pageIletisimBilgileri.Caption = " ";
            this.pageIletisimBilgileri.Name = "pageIletisimBilgileri";
            this.pageIletisimBilgileri.Size = new System.Drawing.Size(924, 259);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.Root.Name = "Root";
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition1.Width = 100D;
            this.Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1});
            rowDefinition1.Height = 100D;
            rowDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            this.Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1});
            this.Root.Size = new System.Drawing.Size(948, 316);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem1.Control = this.tabUst;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(928, 296);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // CariSubeBaglantiEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 449);
            this.Controls.Add(this.DataLayoutGenel);
            this.IconOptions.ShowIcon = false;
            this.MinimumSize = new System.Drawing.Size(950, 450);
            this.Name = "CariSubeBaglantiEditForm";
            this.Text = "Cari Şube Kartı";
            this.Controls.SetChildIndex(this.ribbonControl, 0);
            this.Controls.SetChildIndex(this.DataLayoutGenel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resimMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataLayoutGenel)).EndInit();
            this.DataLayoutGenel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabUst)).EndInit();
            this.tabUst.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            #endregion

            private UserControls.Controls.MyDataLayoutControl DataLayoutGenel;
            private DevExpress.XtraBars.Navigation.TabPane tabUst;
            private DevExpress.XtraLayout.LayoutControlGroup Root;
            private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
            private DevExpress.XtraBars.Navigation.TabNavigationPage pageIletisimBilgileri;
        }
    }