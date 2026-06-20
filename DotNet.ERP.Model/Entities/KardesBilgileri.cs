using DotNet.ERP.Model.Entities.Base;

namespace DotNet.ERP.Model.Entities
{
    public class KardesBilgileri:BaseHareketEntity
    {
        public long TahakkukId { get; set; }
        public long KardesTahakkukId { get; set; }
        public Tahakkuk KardesTahakkuk { get; set; }

    }
}
