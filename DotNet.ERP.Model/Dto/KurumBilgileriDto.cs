using System.ComponentModel.DataAnnotations.Schema;
using DotNet.ERP.Model.Entities;

namespace DotNet.ERP.Model.Dto
{
    [NotMapped]
    public class KurumBilgileriS : KurumBilgileri
    {
        public string VergiDairesiAdi { get; set; }
        //public string IlAdi { get; set; }
        //public string IlceAdi { get; set; }

    }
}
