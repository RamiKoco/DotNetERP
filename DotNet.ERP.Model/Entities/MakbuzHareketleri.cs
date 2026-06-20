using System.ComponentModel.DataAnnotations.Schema;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities.Base;

namespace DotNet.ERP.Model.Entities
{
    public class MakbuzHareketleri : BaseHareketEntity
    {
        public long MakbuzId { get; set; }
        public int OdemeBilgileriId { get; set; }

        [Column(TypeName = "money")]
        public decimal IslemOncesiTutar { get; set; }

        [Column(TypeName = "money")]
        public decimal IslemTutari { get; set; }
        public BelgeDurumu BelgeDurumu { get; set; }
        public long KullaniciId { get; set; }
        public long EskiSubeId { get; set; }
        public long? YeniSubeId { get; set; }


        public Makbuz Makbuz { get; set; }
        public OdemeBilgileri OdemeBilgileri { get; set; }
        public Kullanici Kullanici { get; set; }
        public Sube EskiSube { get; set; }
        public Sube YeniSube { get; set; }

    }
}
