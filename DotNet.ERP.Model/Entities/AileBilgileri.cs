using System.ComponentModel.DataAnnotations;
using DotNet.ERP.Model.Entities.Base;

namespace DotNet.ERP.Model.Entities
{
    public class AileBilgileri : BaseHareketEntity
    {
        public long TahakkukId { get; set; }
        public long AileBilgiId { get; set; }
        [StringLength(500)]
        public string Aciklama { get; set; }
        public AileBilgi AileBilgi { get; set; }
    }
}