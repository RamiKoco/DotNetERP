using DotNet.ERP.Model.Attributes;
using DotNet.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.ERP.Model.Entities.CariEntity.CariTurleri
{
    public class CariTuru : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }
        [Required, StringLength(50), ZorunluAlan("Ad", "txtAd")]
        public string Ad { get; set; }
        public string Aciklama { get; set; }
    }
}