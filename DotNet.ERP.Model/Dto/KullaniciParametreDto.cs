using System.ComponentModel.DataAnnotations.Schema;
using DotNet.ERP.Model.Entities;

namespace DotNet.ERP.Model.Dto
{
    [NotMapped]
    public class KullaniciParametreS : KullaniciParametre
    {
        public string DefaultAvukatHesapAdi { get; set; }
        public string DefaultBankaHesapAdi { get; set; }
        public string DefaultKasaHesapAdi { get; set; }

    }
}
