using DotNet.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.ERP.Model.Dto
{
    [NotMapped]
    public class UyrukS : Entities.Uyruk
    {
        public string UlkeAdi { get; set; }

    }
    public class UyrukL : BaseEntity
    {
        public string Ad { get; set; }
        public string UlkeAdi { get; set; }
        public string Aciklama { get; set; }
    }
}
