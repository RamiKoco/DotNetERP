using DotNet.ERP.Model.Entities;
using DotNet.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.ERP.Model.Dto
{

    [NotMapped]
    public class AdresTurleriS : AdresTurleri
    {
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
    }

    public class AdresTurleriL : BaseEntity
    {
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
    }
}
