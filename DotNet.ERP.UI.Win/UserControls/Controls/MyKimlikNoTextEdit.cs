using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using System.ComponentModel;

namespace DotNet.ERP.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyKimlikNoTextEdit : MyTextEdit
    {
        public MyKimlikNoTextEdit()
        {
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            Properties.Mask.AutoComplete = AutoCompleteType.None;
            StatusBarAciklama = "Kimlik No Giriniz";
        }
    }
}
