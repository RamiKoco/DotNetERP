using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System;
using System.Drawing;

namespace DotNet.ERP.UI.Win.Forms.RenkForms
{
    public partial class RenkListForm : BaseListForm
    {
        public RenkListForm()
        {
            InitializeComponent();
            Bll = new Bll.General.RenkBll();      
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Renk;
            FormShow = new ShowEditForms<RenkEditForm>();
            Navigator = longNavigator.Navigator;
            GridRenkAyarla();

            tablo.CustomDrawCell += Tablo_CustomDrawCell;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((Bll.General.RenkBll)Bll).List(Functions.FilterFunctions.Filter<Model.Entities.Renk>(AktifKartlariGoster));

        }
        private void GridRenkAyarla()
        {
            var colorEdit = new RepositoryItemColorEdit
            {
                ReadOnly = true,
                ShowColorDialog = false,
                TextEditStyle = TextEditStyles.DisableTextEditor
            };

            colForeColor.ColumnEdit = colorEdit;

            // Sayısal değeri gizle, sadece renk kutusu göster
            tablo.CustomColumnDisplayText += (s, e) =>
            {
                if (e.Column.FieldName == "ForeColor")
                    e.DisplayText = "";
            };
        }

        private void Tablo_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "ForeColor")
            {
                e.Handled = true;
                var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

                int colorValue = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, e.Column));
                Color color = Color.FromArgb(colorValue);

                e.Appearance.FillRectangle(e.Cache, e.Bounds);

                Rectangle rect = e.Bounds;

                // Boyutu hücreye göre 2/3 oranında yapıyoruz
                int size = (int)(Math.Min(rect.Width, rect.Height) * 0.66);
                Rectangle colorRect = new Rectangle(
                    rect.X + (rect.Width - size) / 2,
                    rect.Y + (rect.Height - size) / 2,
                    size,
                    size
                );

                using (Brush brush = new SolidBrush(color))
                {
                    e.Graphics.FillRectangle(brush, colorRect);
                    e.Graphics.DrawRectangle(Pens.Black, colorRect);
                }
            }
        }

    }
}