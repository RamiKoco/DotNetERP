using System.ComponentModel;
using DevExpress.XtraEditors;
using System.Drawing;
using DotNet.ERP.UI.Win.Interfaces;

namespace DotNet.ERP.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyTextEdit : TextEdit,IStatusBarAciklama
    {
        
        public MyTextEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.MaxLength = 50;

        }

        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarAciklama { get; set; }
    }
}
