using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities.Base;
using DotNet.ERP.Model.Entities.KisiEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.ERP.Model.Dto.KisiDto
{
    [NotMapped]
    public class KisiS : Kisi
    {
        public string PersonelAdi { get; set; }
        public string KisiGrubuAdi { get; set; }
        public string KayitKaynakAdi { get; set; }
        public string EtiketAdi { get; set; }
        public string MeslekAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public List<Entities.Etiket> Etiketler { get; set; }
    }
    public class KisiL : BaseEntity
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public KayitTuru KayitTuru { get; set; }
        public string EtiketAdi { get; set; }
        public string Aciklama { get; set; }
        public string KisiGrubuAdi { get; set; }
        public string PersonelAdi { get; set; }
        public string KayitKaynakAdi { get; set; }
        public string MeslekAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
    }
}
