using System.Data.Entity;
using System.Data.SqlClient;
using System.Windows.Forms;
using DotNet.ERP.Common.Message;
using DotNet.ERP.UI.Yonetim.Forms.GenelForms;
using DevExpress.XtraSplashScreen;

namespace DotNet.ERP.UI.Yonetim.Functions
{
    public class GeneralFunctions
    {
        protected internal static bool CreateDatabase<TContext>(string splashCaption, string splashDescription, string onayMesaj, string bilgiMesaj) where TContext : DbContext, new()
        {
            using (var con = new TContext())
            {
                con.Database.Connection.ConnectionString = Bll.Functions.GeneralFunctions.GetConnectionString();
                if (con.Database.Exists()) return true;

                if (Messages.EvetSeciliEvetHayir(onayMesaj, "Onay") != DialogResult.Yes) return false;
                var splashForm = new SplashScreenManager(Form.ActiveForm, typeof(BekleForm), true, true);
                SplashBaslat(splashForm);

                splashForm.SetWaitFormCaption(splashCaption);
                splashForm.SetWaitFormDescription(splashDescription);

                try
                {
                    if (con.Database.CreateIfNotExists())
                    {
                        SplashDurdur(splashForm);
                        Messages.BilgiMesaji(bilgiMesaj);
                        return true;
                    }

                }
                catch (SqlException ex)
                {
                    SplashDurdur(splashForm);

                    switch (ex.Number)
                    {
                        case 5170:
                            Messages.HataMesaji("Veritabanı Dosyalarının Yükleneceği Klasörde Aynı İsimde Zaten Bir Dosya Var. Lütfen Kontrol Ediniz.\n\n"+ex.Message);
                            break;
                        default:
                            Messages.HataMesaji(ex.Message);
                            break;
                    }
                }

                return false;
            }

        }

        private static void SplashBaslat(SplashScreenManager manager)
        {
            if (manager.IsSplashFormVisible)
            {
                manager.CloseWaitForm();
                manager.ShowWaitForm();
            }
            else
                manager.ShowWaitForm();
        }

        private static void SplashDurdur(SplashScreenManager manager)
        {
            if (manager.IsSplashFormVisible)
                manager.CloseWaitForm();
        }

        protected internal static bool DeleteDatabase<TContext>() where TContext : DbContext, new()
        {
            using (var con = new TContext())
            {
                con.Database.Connection.ConnectionString = Bll.Functions.GeneralFunctions.GetConnectionString();

                if (Messages.HayirSeciliEvetHayir(
                        "Seçtiğiniz Kurum ve Kurum İşlemlerinin Tamamı İçeren Kurum Veritabanı (Veritabanı Dosyaları Dahil) Tamamen Silinecektir. Onaylıyor Musunuz?",
                        "Silme Onay") != DialogResult.Yes) return false;
                if (Messages.HayirSeciliEvetHayir(
                        "Seçtiğiniz Kurum ve Kurum İşlemlerinin Tamamı İçeren Kurum Veritabanı (Veritabanı Dosyaları Dahil) Tamamen Silinecektir. Tekrar Onaylıyor Musunuz?",
                        "Silme Onay") != DialogResult.Yes) return false;

                try
                {
                    if (con.Database.Delete())
                    {
                        Messages.BilgiMesaji("Kurum Silme İşlemi Başarılı Bir Şekilde Tamamlanmıştır.");
                        return true;
                    }
                }
                catch (SqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 3702:
                            Messages.HataMesaji("Veritabanı Kullanımda Olduğu İçin Silinemedi. Lütfen Veritabanına Yapılan Tüm Bağlantıları Sonlandırdıktan Sonra Tekrar Deneyiniz.");
                            break;
                        default:
                            Messages.HataMesaji(ex.Message);
                            break;
                    }
                }

                return false;
            }

        }
    }
}
