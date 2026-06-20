using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using DotNet.ERP.UI.Yonetim.Forms.GenelForms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;

namespace DotNet.ERP.UI.Yonetim
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Win.Forms.Functions.GeneralFunctions.EncryptConfigFile(AppDomain.CurrentDomain.SetupInformation.ApplicationName, "connectionStrings", "appSettings");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr-TR");

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            Application.SetCompatibleTextRenderingDefault(false);
            //UserLookAndFeel.Default.SetSkinStyle("Office 2016 Colorful");
            Application.Run(new GirisForm());
        }
    }
}
