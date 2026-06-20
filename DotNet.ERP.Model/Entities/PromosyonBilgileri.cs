using DotNet.ERP.Model.Entities.Base;

namespace DotNet.ERP.Model.Entities
{
    public class PromosyonBilgileri : BaseHareketEntity
    {
        public long TahakkukId { get; set; }
        public long PromosyonId { get; set; }

        public Promosyon Promosyon { get; set; }

    }
}
