using System.ComponentModel;
using System.Drawing;
using DotNet.ERP.UI.Win.Interfaces;
using DevExpress.XtraEditors;

namespace DotNet.ERP.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyCheckEdit:CheckEdit,IStatusBarAciklama
    {
        public MyCheckEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.Transparent;
        }
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarAciklama { get ; set; }
    }
}