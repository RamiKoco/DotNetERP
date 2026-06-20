using DotNet.ERP.Model.Attributes;
using DotNet.ERP.Model.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotNet.ERP.Model.Entities
{
    public class Ulke : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }
        [Required, StringLength(50), ZorunluAlan("Ülke Adı", "txtUlkeAdi")]
        public string UlkeAdi { get; set; }
        [StringLength(500)]
        public string Aciklama { get; set; }
        //[InverseProperty("Ulke")]
        public ICollection<Il> Il { get; set; }
    }
}