using DevExpress.XtraPrinting;

namespace DotNet.ERP.UI.Win.GenelForms
{
    public partial class RaporOnizleme : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RaporOnizleme(params object[] prm)
        {
            InitializeComponent();

            RaporGosterici.PrintingSystem = (PrintingSystemBase) prm[0];
            Text = $"{Text} ( {prm[1].ToString()} )";

        }

    }
}