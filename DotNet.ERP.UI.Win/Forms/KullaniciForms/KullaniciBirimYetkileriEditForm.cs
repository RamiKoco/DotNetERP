using System;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DevExpress.XtraBars;

namespace DotNet.ERP.UI.Win.Forms.KullaniciForms
{
    public partial class KullaniciBirimYetkileriEditForm : BaseEditForm
    {
        public KullaniciBirimYetkileriEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            EventsLoad();
            HideItems = new BarItem[] { btnYeni, btnSil, btnKaydet, btnGerial };
            TabloYukle();
        }

        public override void Yukle()
        {
            subeTable.Yukle();
            donemTable.Yukle();
        }

        protected internal override void ButonEnabledDurumu() { }
        protected override void BaseEditForm_Shown(object sender, EventArgs e)
        {
            kullaniciTable.Tablo.Focus();
        }

        protected override void TabloYukle()
        {
            kullaniciTable.OwnerForm = this;
            subeTable.OwnerForm = this;
            donemTable.OwnerForm = this;
            kullaniciTable.Yukle();
        }
    }
}