using System;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using DotNet.ERP.UI.Win.GenelForms;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;


namespace DotNet.ERP.UI.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Forms.Functions.GeneralFunctions.EncryptConfigFile(AppDomain.CurrentDomain.SetupInformation.ApplicationName, "connectionStrings", "appSettings");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr-TR");

            //BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle(ConfigurationManager.AppSettings["Skin"], ConfigurationManager.AppSettings["Palette"]);
            Application.Run(new GirisForm());
        }
    }
}
