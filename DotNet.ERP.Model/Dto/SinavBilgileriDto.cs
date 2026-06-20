using System.ComponentModel.DataAnnotations.Schema;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.Model.Entities.Base.Interfaces;

namespace DotNet.ERP.Model.Dto
{
    [NotMapped]
    public class SinavBilgileriL:SinavBilgileri,IBaseHareketEntity
    {
        public bool Insert { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
    }
}
