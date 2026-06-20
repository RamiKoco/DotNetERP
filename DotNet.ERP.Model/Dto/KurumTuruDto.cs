using DotNet.ERP.Model.Entities;
using DotNet.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.ERP.Model.Dto
{
    [NotMapped]
    public class KurumTuruS : KurumTuru
    {
    }
    public class KurumTuruL : BaseEntity
    {
        public override string Kod { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
    }
}
