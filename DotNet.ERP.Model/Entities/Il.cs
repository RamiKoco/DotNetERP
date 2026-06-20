using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DotNet.ERP.Model.Attributes;
using DotNet.ERP.Model.Entities.Base;
namespace DotNet.ERP.Model.Entities
{    
   public class Il:BaseEntityDurum
    {
        [Index("IX_Kod",IsUnique = true)]
        public override string Kod { get; set; }
        [Required,StringLength(50),ZorunluAlan("İl Adı","txtIlAdi")]
        public string Ad { get; set; }
        [StringLength(500)]
        public string Aciklama { get; set; }
        [InverseProperty("Il")]
        public ICollection<Ilce> Ilce { get; set; }        
    }
}