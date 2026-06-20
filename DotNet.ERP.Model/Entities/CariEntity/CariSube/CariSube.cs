using DotNet.ERP.Model.Attributes;
using DotNet.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotNet.ERP.Model.Entities.CariEntity.CariSube
{
    public class CariSube : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = false)]
        public override string Kod { get; set; }

        [Required, StringLength(200), ZorunluAlan("Cari Şube", "txtCariSube")]
        public string Ad { get; set; }
        public long CariId { get; set; }
        public long? CariSubeGrubuId { get; set; }
        public long? OzelKod1Id { get; set; }
        public long? OzelKod2Id { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }
        public Cari Cari { get; set; }
        public CariSubeGrubu CariSubeGrubu { get; set; }
        public OzelKod OzelKod1 { get; set; }
        public OzelKod OzelKod2 { get; set; }
    }
}