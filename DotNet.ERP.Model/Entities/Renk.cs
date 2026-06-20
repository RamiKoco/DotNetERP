using DotNet.ERP.Model.Attributes;
using DotNet.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace DotNet.ERP.Model.Entities
{
    public class Renk : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }
        [Required, StringLength(50), ZorunluAlan("Renk Adı", "txtRenk")]
        public string RenkAdi { get; set; }
        public string RGB { get; set; }
        public int ForeColor { get; set; } = Color.Maroon.ToArgb();
        public long? OzelKod1Id { get; set; }
        public long? OzelKod2Id { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }
        public OzelKod OzelKod1 { get; set; }
        public OzelKod OzelKod2 { get; set; }
    }
}