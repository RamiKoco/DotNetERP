using System.ComponentModel;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;

namespace DotNet.ERP.UI.Win.UserControls.Controls
{
    public class MyCardEdit : MyTextEdit
    {
        [ToolboxItem(true)]
        public MyCardEdit()
        {
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            Properties.Mask.MaskType = MaskType.Regular;
            Properties.Mask.EditMask = @"\d?\d?\d?\d?-\d?\d?\d?\d?-\d?\d?\d?\d?-\d?\d?\d?\d?";
            Properties.Mask.AutoComplete = AutoCompleteType.None;
            StatusBarAciklama = "Kart No Giriniz.";     
        }
    }
}