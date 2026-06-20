using DotNet.ERP.Model.Attributes;
using System.ComponentModel.DataAnnotations;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities.Base;

namespace DotNet.ERP.Model.Entities
{
    public class MailParametre : BaseEntity
    {

        [Required, StringLength(50), ZorunluAlan("Email", "txtEmail")]
        public string Email { get; set; }

        [Required, StringLength(50), ZorunluAlan("Email Şifre", "txtSifre")]
        public string Sifre { get; set; }

        [ZorunluAlan("Port No", "txtPortNo")]
        public int PortNo { get; set; }

        [Required, StringLength(50), ZorunluAlan("Host", "txtHost")]
        public string Host { get; set; }

        public EvetHayir SslKullan { get; set; } = EvetHayir.Evet;
    }
}
