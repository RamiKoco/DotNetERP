using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Attributes;
using DotNet.ERP.Model.Entities.Base;

namespace DotNet.ERP.Model.Entities
{
    public class OdemeTuru:BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }

        [Required,StringLength(50),ZorunluAlan("Ödeme Türü Adı", "txtOdemeTuruAdi")]
        public string OdemeTuruAdi { get; set; }
        public OdemeTipi OdemeTipi { get; set; } = OdemeTipi.Elden;
        
        [StringLength(500)]
        public string Aciklama { get; set; }
    }
}
