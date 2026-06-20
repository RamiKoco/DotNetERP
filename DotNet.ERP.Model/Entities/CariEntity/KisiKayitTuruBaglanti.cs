using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities.Base;
using DotNet.ERP.Model.Entities.KisiEntity;
using System.ComponentModel.DataAnnotations;

namespace DotNet.ERP.Model.Entities.CariEntity
{
    public class KisiKayitTuruBaglanti : BaseHareketEntity
    {      
        public long KayitId { get; set; }
        public KayitTuru KayitTuru { get; set; }
        public long? KisiId { get; set; }
        public long? PozisyonId { get; set; }
        [StringLength(200)]
        public string Aciklama { get; set; }
        public Kisi Kisi { get; set; }
        public Pozisyon Pozisyon { get; set; }
    }
}