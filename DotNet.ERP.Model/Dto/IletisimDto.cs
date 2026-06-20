using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.Model.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.ERP.Model.Dto
{
    [NotMapped]
    public class IletisimS : Iletisim
    {
        public string SosyalMedyaPlatformuAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public string IlgiliKisiAdi { get; set; }
      
    }
    public class IletisimL : BaseEntity
    {
        public KayitTuru KayitTuru { get; set; }
        public IletisimTuru IletisimTuru { get; set; }
        public IletisimDurumu IzinDurumu { get; set; }
        public IletisimKanalTipi IletisimKanalTipi { get; set; }
        public string Baslik { get; set; }
        public string Kanallar { get; set; }
        public bool Arama { get; set; }
        public bool Sms { get; set; }
        public bool Whatsapp { get; set; }
        public bool EPBool { get; set; }
        public string Ilgili { get; set; }
        public string UlkeKodu { get; set; }
        public string Numara { get; set; }
        public string DahiliNo { get; set; }
        public string EPosta { get; set; }
        public DateTime? IzinTarihi { get; set; }
        public string KullaniciAdi { get; set; }
        public string SosyalMedyaUrl { get; set; }
        public string SIPKullaniciAdi { get; set; }
        public string SIPServer { get; set; }
        public short Oncelik { get; set; }
        public bool VoipMi { get; set; }
        public string Web { get; set; }
        public string AnaKayitHesabiAdi { get; set; }
        public string KayitHesabiAdi { get; set; }       
        public long? AnaKayitId { get; set; }
        public long? KayitId { get; set; }
        public string SosyalMedyaPlatformuAdi { get; set; }
        public string Aciklama { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public string IlgiliKisiAdi { get; set; }
    }
}
