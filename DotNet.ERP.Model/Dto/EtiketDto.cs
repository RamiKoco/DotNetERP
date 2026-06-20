using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.ERP.Model.Dto
{
    [NotMapped]
    public class EtiketS : Entities.Etiket
    {
        public string RenkAdi { get; set; }
        public string RenkRGB { get; set; }
        public int? RenkForeColor { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
    }
    public class EtiketL : BaseEntity
    {
        public string Ad { get; set; }
        public KayitTuru KayitTuru { get; set; }
        public string Aciklama { get; set; }
        public string RenkAdi { get; set; }
        public string RenkRGB { get; set; }
        public int? RenkForeColor { get; set; }
        public int YaziRgbKodu { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
    }
}
