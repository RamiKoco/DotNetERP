using DotNet.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.ERP.Model.Entities
{
    public class EklerDepolamaAyarlari : BaseEntity
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }
        [StringLength(60)]
        public string KokDizin { get; set; }       
    }
}