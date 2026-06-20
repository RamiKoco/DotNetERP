using DotNet.ERP.Model.Entities.Base;
namespace DotNet.ERP.Model.Entities
{
    public class AdresHareketleri : BaseHareketEntity
    {
        public long? KisiId { get; set; }
        public long? PersonelId { get; set; }
        public long AdresBilgileriId { get; set; }
        public long GenelAdresId { get; set; }
        public Adresler GenelAdres { get; set; }
    }
}