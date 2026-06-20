using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities.Base;

namespace DotNet.ERP.Model.Entities
{
    public class IletisimBilgi : BaseHareketEntity
    {
        public long? KisiId { get; set; }
        public long? PersonelId { get; set; }
        public long IletisimlerId { get; set; }
        public bool Veli { get; set; }
        public IletisimTuru? IletisimTuru { get; set; }      
    }
}