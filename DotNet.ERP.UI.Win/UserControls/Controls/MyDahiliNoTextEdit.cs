using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using System;
using System.ComponentModel;

namespace DotNet.ERP.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyDahiliNoTextEdit : MyTextEdit
    {
        public MyDahiliNoTextEdit()
        {
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;    
            Properties.Mask.MaskType = MaskType.RegEx;
            Properties.Mask.EditMask = @"[1-9]\d{0,5}";
            Properties.Mask.PlaceHolder = ' ';
            Properties.Mask.AutoComplete = AutoCompleteType.Strong;
            Properties.Mask.UseMaskAsDisplayFormat = true;
            StatusBarAciklama = "Dahili No Giriniz.";
            Enter += (s, e) =>
            {
                BeginInvoke(new Action(() => Select(1, 0)));
            };
        }
    }
}
