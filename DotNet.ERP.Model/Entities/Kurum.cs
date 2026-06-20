using DotNet.ERP.Model.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities.Base;

namespace DotNet.ERP.Model.Entities
{
    public class Kurum : BaseEntity
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }

        [Required, StringLength(50), ZorunluAlan("Kurum Adı", "txtKurumAdi")]
        public string Ad { get; set; }

        [Required, StringLength(100), ZorunluAlan("Server", "txtServer")]
        public string Server { get; set; }

        public YetkilendirmeTuru YetkilendirmeTuru { get; set; } = YetkilendirmeTuru.SqlServer;

        [Required, StringLength(50), ZorunluAlan("Kullanıcı Adı", "txtKullaniciAdi")]
        public string KullaniciAdi { get; set; }

        [Required, StringLength(50), ZorunluAlan("Sifre", "txtSifre")]
        public string Sifre { get; set; }
    }
}