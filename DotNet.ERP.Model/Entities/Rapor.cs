using DotNet.ERP.Model.Attributes;
using DotNet.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DotNet.ERP.Common.Enums;

namespace DotNet.ERP.Model.Entities
{
    public class Rapor:BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = false)]
        public override string Kod { get; set; }

        [Required, StringLength(50), ZorunluAlan("Rapor Adı", "txtRaporAdi")]
        public string RaporAdi { get; set; }
        public KartTuru RaporTuru { get; set; }
        public RaporBolumTuru RaporBolumTuru { get; set; }

        [Required]
        public byte[] Dosya { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

    }
}
