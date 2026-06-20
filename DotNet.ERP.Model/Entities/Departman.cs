using DotNet.ERP.Model.Attributes;
using DotNet.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.ERP.Model.Entities
{
    public class Departman : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }
        [Required, StringLength(50), ZorunluAlan("Departman Adı", "txtDepartmanAdi")]
        public string Ad { get; set; }
        [StringLength(500)]
        public string Aciklama { get; set; }
    }
}