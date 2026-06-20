using System.ComponentModel;
using System.Drawing;
using DotNet.ERP.UI.Win.Interfaces;
using DevExpress.XtraEditors;

namespace DotNet.ERP.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
   public class MySimpleButton:SimpleButton,IStatusBarAciklama
    {
        public MySimpleButton()
        {
            Appearance.ForeColor = Color.Maroon;

        }

        public string StatusBarAciklama { get; set; }
    }
}
