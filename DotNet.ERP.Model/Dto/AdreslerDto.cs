using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.ERP.Model.Dto
{
    [NotMapped]
    public class AdreslerS : Adresler
    {
        public string AdresTurleriAdi { get; set; }
        public string UlkeAdi { get; set; }
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        //public string KayitHesabiAdi { get; set; }
    }
    public class AdreslerL : BaseEntity
    {
        public KayitTuru KayitTuru { get; set; }
        public long? AnaKayitId { get; set; }
        public long? KayitId { get; set; }
        public string UlkeAdi { get; set; }
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public string AdresTurleriAdi { get; set; }
        public string Aciklama { get; set; }
        public string Baslik { get; set; }
        public string AdresNotu { get; set; }
        public string PostaKodu { get; set; }
        public string Adres { get; set; }
        public string KayitHesabiAdi { get; set; }
        public string AnaKayitHesabiAdi { get; set; }
        public AdresTipi AdresTipi { get; set; }
        public decimal Enlem { get; set; }
        public decimal Boylam { get; set; }
        public bool VarsayilanMi { get; set; }
        public bool VarsayilanFaturaMi { get; set; }
        public bool VarsayilanSevkiyatMi { get; set; }
    }
}
