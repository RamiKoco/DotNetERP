using System.ComponentModel;
using System.Drawing;
using DotNet.ERP.UI.Win.Interfaces;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace DotNet.ERP.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyLookUpEdit : LookUpEdit , IStatusBarKisaYol
    {
        public MyLookUpEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.HeaderClickMode = HeaderClickMode.AutoSearch;
            Properties.ShowFooter = false;
        }

        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; } = "Seçim Yap";
        public string StatusBarAciklama { get; set; }

    }
}
