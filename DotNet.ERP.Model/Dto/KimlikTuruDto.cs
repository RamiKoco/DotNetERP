using DotNet.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.ERP.Model.Dto
{
    [NotMapped]
    public class KimlikTuruS : Entities.KimlikTuru
    {
        public string UlkeAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }

    }
    public class KimlikTuruL : BaseEntity
    {
        public string Ad { get; set; }
        public string UlkeAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public string Aciklama { get; set; }
        public string KarakterTipi { get; set; }
        public int Uzunluk { get; set; }
    }
}
