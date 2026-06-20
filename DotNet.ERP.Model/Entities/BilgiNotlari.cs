using System;
using System.ComponentModel.DataAnnotations;
using DotNet.ERP.Model.Entities.Base;

namespace DotNet.ERP.Model.Entities
{
    public class Yorumlar: BaseHareketEntity
    {        
        public long TahakkukId { get; set; }
        public long KisiId { get; set; }
        public long PersonelId { get; set; }
        public long CarilerId { get; set; }
        public long CariSubelerId { get; set; }
        public DateTime Tarih { get; set; }
        [Required,StringLength(1000)]
        public string Yorum { get; set; }       
    }
}