using DotNet.ERP.Model.Entities;
using DotNet.ERP.Model.Entities.Base.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.ERP.Model.Dto
{
    [NotMapped]
    public class EklerL : Ekler, IBaseHareketEntity
    {
        public string BelgeAdi { get; set; }
        public string EkleyenKullaniciAdi { get; set; }
        public string YeniDosyaTempYolu { get; set; }
        public string EskiDosyaTempYolu { get; set; }
        public bool Insert { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }     
    }   
}