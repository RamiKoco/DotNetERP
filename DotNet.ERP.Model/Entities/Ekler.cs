using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
namespace DotNet.ERP.Model.Entities
{
    public class Ekler : BaseHareketEntity
    {
        public KayitTuru KayitTuru { get; set; }
        public long? KayitId { get; set; }    

        [StringLength(100)]
        public string Baslik { get; set; }
        [StringLength(200)]
        public string DosyaYolu { get; set; }      
        [StringLength(100)]
        public string DosyaAdi { get; set; }
        [StringLength(20)]
        public string DosyaUzantisi { get; set; }
        public long DosyaBoyutu { get; set; }
        public long? BelgeTuruId { get; set; }
        public long? EkleyenKullaniciId { get; set; }   
        public DateTime EklemeTarihi { get; set; }

        [StringLength(200)]
        public string Aciklama { get; set; }
        public BelgeTuru BelgeTuru { get; set; }
        public Kullanici EkleyenKullanici { get; set; }
    }
}
