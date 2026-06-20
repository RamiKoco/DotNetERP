using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities.Base;

namespace DotNet.ERP.Model.Entities
{
    public class KullaniciBirimYetkileri : BaseHareketEntity
    {
        public long KullaniciId { get; set; }
        public KartTuru KartTuru { get; set; }
        public long? SubeId { get; set; }
        public long? DonemId { get; set; }

        public Kullanici Kullanici { get; set; }
        public Sube Sube { get; set; }
        public Donem Donem { get; set; }
    }
}
