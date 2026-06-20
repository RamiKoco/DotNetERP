using DotNet.ERP.Model.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.ERP.Model.Entities.PersonelEntity
{
    public class PersonelBelge : BaseHareketEntity
    {
        public long PersonelId { get; set; }
        [StringLength(30)]
        public string BelgeNo { get; set; }
        [Column(TypeName = "date")]
        public DateTime VerilisTarihi { get; set; }
        [Column(TypeName = "date")]
        public DateTime GecerlilikTarihi { get; set; }
        public long? BelgeTuruId { get; set; }
        public long? KurumlarId { get; set; }
        [StringLength(200)]
        public string Aciklama { get; set; }
        public Personel Personel { get; set; }
        public BelgeTuru BelgeTuru { get; set; }
        public Kurumlar Kurumlar { get; set; }
    }
}