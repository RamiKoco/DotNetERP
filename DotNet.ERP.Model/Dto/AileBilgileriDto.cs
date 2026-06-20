using System.ComponentModel.DataAnnotations.Schema;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.Model.Entities.Base.Interfaces;

namespace DotNet.ERP.Model.Dto
{
    [NotMapped]
    public class AileBilgileriL:AileBilgileri,IBaseHareketEntity
    {
        public string BilgiAdi { get; set; }
        public bool Insert { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
    }
}
