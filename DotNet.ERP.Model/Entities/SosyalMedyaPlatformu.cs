using DotNet.ERP.Model.Attributes;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.ERP.Model.Entities
{
    public class SosyalMedyaPlatformu : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = false)]
        public override string Kod { get; set; }

        [Required, StringLength(50), ZorunluAlan("Ad", "txtAd")]
        public string Ad { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }
        public long? OzelKod1Id { get; set; }
        public long? OzelKod2Id { get; set; }

        public OzelKod OzelKod1 { get; set; }
        public OzelKod OzelKod2 { get; set; }
    }
}
