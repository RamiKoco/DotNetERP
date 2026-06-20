using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Attributes;
using DotNet.ERP.Model.Entities.Base;
using DotNet.ERP.Model.Entities.CariEntity;
using DotNet.ERP.Model.Entities.CariEntity.CariSube;
using DotNet.ERP.Model.Entities.KisiEntity;
using DotNet.ERP.Model.Entities.PersonelEntity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.ERP.Model.Entities
{
    public class Iletisim : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = false)]
        public override string Kod { get; set; }
        [Required, StringLength(30), ZorunluAlan("Baslik", "txtBaslik")]
        public string Baslik { get; set; }
        public KayitTuru KayitTuru { get; set; }
        public long? KayitId { get; set; }
        public long? AnaKayitId { get; set; }
        public IletisimTuru IletisimTuru { get; set; } = IletisimTuru.Telefon;
        public IletisimDurumu IzinDurumu { get; set; } = IletisimDurumu.Belirtilmedi;
        public IletisimKanalTipi IletisimKanalTipi { get; set; } = IletisimKanalTipi.Arama;

        [StringLength(6)]
        public string UlkeKodu { get; set; }

        [StringLength(17)]
        public string Numara { get; set; }

        [StringLength(10)]
        public string DahiliNo { get; set; }
        [StringLength(60)]
        public string EPosta { get; set; }
      
        public string Kanallar { get; set; }
        public bool Arama { get; set; }
        public bool Sms { get; set; }
        public bool Whatsapp { get; set; }
        public bool EPBool { get; set; }
        public string AnaKayitHesabiAdi { get; set; }
        public string KayitHesabiAdi { get; set; }     
        public string KullaniciAdi { get; set; }
        public string SosyalMedyaUrl { get; set; }
        public string SIPKullaniciAdi { get; set; }
        public string SIPServer { get; set; }
        public short Oncelik { get; set; }
        public bool VoipMi { get; set; } = false;
        [Column(TypeName = "date")]
        public DateTime? IzinTarihi { get; set; }

        [StringLength(50)]
        public string Web { get; set; }
        public long? CariId { get; set; }
        public long? CariSubeId { get; set; }
        public long? KisiId { get; set; }
        public long? IlgiliKisiId { get; set; }
        public long? PersonelId { get; set; }
        public long? SosyalMedyaPlatformuId { get; set; }
        public long? OzelKod1Id { get; set; }
        public long? OzelKod2Id { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        public Cari Cari { get; set; }
        public CariSube CariSube { get; set; }
        public Kisi Kisi { get; set; }
        public Kisi IlgiliKisi { get; set; }
        public Personel Personel { get; set; }       
        public SosyalMedyaPlatformu SosyalMedyaPlatformu { get; set; }
        public OzelKod OzelKod1 { get; set; }
        public OzelKod OzelKod2 { get; set; }
    }
}