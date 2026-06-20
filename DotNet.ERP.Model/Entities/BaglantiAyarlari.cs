using System.Security;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities.Base;

namespace DotNet.ERP.Model.Entities
{
    public class BaglantiAyarlari : BaseEntity
    {
        public string Server { get; set; }
        public YetkilendirmeTuru YetkilendirmeTuru { get; set; }
        public SecureString KullaniciAdi { get; set; }
        public SecureString Sifre { get; set; }

    }
}