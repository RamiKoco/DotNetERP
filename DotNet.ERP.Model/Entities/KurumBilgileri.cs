using DotNet.ERP.Model.Attributes;
using DotNet.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace DotNet.ERP.Model.Entities
{
    public class KurumBilgileri : BaseEntity
    {

        [Required, StringLength(50), ZorunluAlan("Kurum Adı", "txtKurumAdi")]
        public string KurumAdi { get; set; }

        [StringLength(20)]
        public string VergiNo { get; set; }

        public long? VergiDairesiId { get; set; }

        //[ZorunluAlan("İl Adı", "txtIl")]
        //public long IlId { get; set; }

        //[ZorunluAlan("İlçe Adı", "txtIlce")]
        //public long IlceId { get; set; }

        //public Il Il { get; set; }
        //public Ilce Ilce { get; set; } cc
        public VergiDairesi VergiDairesi { get; set; }
    }
}
