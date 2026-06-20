using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Runtime.InteropServices;
using System.Security;
using DotNet.Dal.Base;
using DotNet.Dal.Interfaces;
using DotNet.ERP.Model.Entities.Base.Interfaces;
using DevExpress.Utils.Extensions;

namespace DotNet.ERP.Bll.Functions
{
   public static class GeneralFunctions
    {
        public static List<string> DegisenAlanlariGetir<T>(this T oldEntity, T currentEntity)
        {
            List<string> alanlar = new List<string>();

            foreach (var prop in currentEntity.GetType().GetProperties())
            {
                if (prop.PropertyType.Namespace == "System.Collections.Generic") continue;
                var oldValue = prop.GetValue(oldEntity) ?? string.Empty;
                var currentValue = prop.GetValue(currentEntity) ?? string.Empty;

                if (prop.PropertyType == typeof(byte[]))
                {
                    if (string.IsNullOrEmpty(oldValue.ToString()))
                        oldValue = new byte[] {0};
                    if (string.IsNullOrEmpty(currentValue.ToString()))
                        currentValue = new byte[] {0};

                    if (((byte[])oldValue).Length != ((byte[])currentValue).Length)
                        alanlar.Add(prop.Name);
                }

               else if (prop.PropertyType == typeof(SecureString))
                {
                    var oldStr = ((SecureString)oldValue).ConvertToUnSecureString();
                    var curStr = ((SecureString)currentValue).ConvertToUnSecureString();

                    if (!oldStr.Equals(curStr))
                        alanlar.Add(prop.Name);
                }


                else if(!currentValue.Equals(oldValue))
                    alanlar.Add(prop.Name);
            }

            return alanlar;
        }
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ERPContext"].ConnectionString;

        }
        private static TContext CreateContext<TContext>() where TContext : DbContext
        {

            return (TContext) Activator.CreateInstance(typeof(TContext), GetConnectionString());
        }
        public static void CreateUnitOfWork<T, TContext>(ref IUnitOfWork<T> uow)
            where T : class, IBaseEntity where TContext : DbContext
        {
            uow?.Dispose();
            uow = new UnitOfWork<T>(CreateContext<TContext>());
        }
        public static SecureString ConvertToSecureString(this string value)
        {
            var secureString = new SecureString();

            if (value.Length > 0)
                value.ToCharArray().ForEach(x => secureString.AppendChar(x));

            secureString.MakeReadOnly();
            return secureString;
        }
        public static string ConvertToUnSecureString(this SecureString value)
        {
            var result = Marshal.SecureStringToBSTR(value);
            return Marshal.PtrToStringAuto(result);
        }
    }
}