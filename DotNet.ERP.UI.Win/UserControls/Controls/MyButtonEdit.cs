using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Drawing;
using DotNet.ERP.UI.Win.Interfaces;
using System;
using System.ComponentModel;

namespace DotNet.ERP.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyButtonEdit:ButtonEdit,IStatusBarKisaYol
    {
        public bool IsClearButtonClick { get; internal set; }
        public MyButtonEdit()
        {
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.Buttons.Clear();
            Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
            Properties.Buttons.Add(new EditorButton(ButtonPredefines.Ellipsis));
            ButtonClick += MyButtonEdit_ButtonClick;
        }
        private void MyButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            IsClearButtonClick = false;

            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                IsClearButtonClick = true;
                Text = null;
                Id = null;
            }
        }
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarAciklama { get; set; }
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; }

        #region Events

        private long? _id;
        
        [Browsable(false)]
        public long? Id
        {
            get => _id;

            set
            {
                var oldValue = _id;
                var newValue = value;

                if (newValue.HasValue && oldValue.HasValue && newValue == oldValue) return;
                _id = value;
                IdChanged(this, new IdChangedEventArgs(oldValue, newValue));
                EnabledChange(this,EventArgs.Empty);
            }
        }
        public event EventHandler<IdChangedEventArgs> IdChanged = delegate { };
        public event EventHandler EnabledChange = delegate { };

        #endregion

    }
    public class IdChangedEventArgs : EventArgs
  {
      public IdChangedEventArgs(long? oldValue,long? newValue)
      {
          OldValue = oldValue;
          NewValue = newValue;

      }

      public long? OldValue  { get;}
      public long? NewValue { get; }

  }
}
