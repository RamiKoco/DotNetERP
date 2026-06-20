using System.ComponentModel.DataAnnotations.Schema;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.Model.Entities.Base;

namespace DotNet.ERP.Model.Dto
{
    [NotMapped]
    public class KasaS:Kasa
    {
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
    }

    public class KasaL : BaseEntity
    {
        public string KasaAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public string Aciklama { get; set; }
    }
}
