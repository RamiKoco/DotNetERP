using System.ComponentModel;
using System.Drawing;
using DotNet.ERP.UI.Win.Interfaces;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace DotNet.ERP.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
   public class MyPictureEdit:PictureEdit,IStatusBarKisaYol
    {
        public MyPictureEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.Appearance.ForeColor = Color.Maroon;
            Properties.NullText = "Resim Yok";
            Properties.SizeMode = PictureSizeMode.Stretch;
            Properties.ShowMenu = false;
        }

        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }
    }
}
