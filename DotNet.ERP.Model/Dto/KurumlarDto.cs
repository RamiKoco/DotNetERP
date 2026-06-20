using DotNet.ERP.Model.Entities;
using DotNet.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.ERP.Model.Dto
{
    [NotMapped]
    public class KurumlarS : Kurumlar
    {
        public string KurumTuruAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
    }
    public class KurumlarL : BaseEntity
    {
        public override string Kod { get; set; }
        public string Ad { get; set; }
        public string KurumTuruAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public string Aciklama { get; set; }
    }
}
