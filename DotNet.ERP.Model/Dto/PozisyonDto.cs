using DotNet.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.ERP.Model.Dto
{

    [NotMapped]
    public class PozisyonS : Entities.Pozisyon
    {
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }

    }

    public class PozisyonL : BaseEntity
    {
        public string Ad { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public string Aciklama { get; set; }

    }
}
