using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Reports.FormReports.Base;
using System.Windows.Forms;
using System;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Show
{
    public class ShowEditReports <TForm>  where TForm : BaseRapor
    {
        public static void ShowEditReport(KartTuru kartTuru)
        {
            if (!kartTuru.YetkiKontrolu(YetkiTuru.Gorebilir)) return;

            var frm = (TForm)Activator.CreateInstance(typeof(TForm));
            frm.MdiParent = Form.ActiveForm;

            frm.Yukle();
            frm.Show();
        }

    }
}
