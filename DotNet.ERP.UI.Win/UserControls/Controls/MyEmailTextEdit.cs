using System.ComponentModel;
using DevExpress.XtraEditors.Mask;

namespace DotNet.ERP.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
   public class MyEmailTextEdit:MyTextEdit
    {
        public MyEmailTextEdit()
        {
            Properties.Mask.MaskType = MaskType.RegEx;
            Properties.Mask.EditMask = @"((([0-9a-zA-Z_%-])+[.])+|([0-9a-zA-Z_%-])+)+@((([0-9a-zA-Z_-])+[.])+|([0-9a-zA-Z_-])+)+";
            Properties.Mask.AutoComplete = AutoCompleteType.Strong;
            StatusBarAciklama = "E-Mail Adresi Giriniz.";
        }
    }
}