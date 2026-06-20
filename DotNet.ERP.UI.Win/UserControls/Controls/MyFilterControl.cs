using System.ComponentModel;
using DotNet.ERP.UI.Win.Interfaces;
using DevExpress.XtraEditors;

namespace DotNet.ERP.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
   public class MyFilterControl:FilterControl,IStatusBarAciklama
    {
        public MyFilterControl()
        {
            ShowGroupCommandsIcon = true;
        }
        public string StatusBarAciklama { get; set; } = "Filtre Metni Giriniz.";
    }
}
