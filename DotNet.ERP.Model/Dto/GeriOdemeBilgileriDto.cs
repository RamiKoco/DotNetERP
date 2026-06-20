using System;
using System.ComponentModel.DataAnnotations.Schema;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.Model.Entities.Base.Interfaces;
using DevExpress.DataAccess.ObjectBinding;

namespace DotNet.ERP.Model.Dto
{
    [NotMapped]
    public class GeriOdemeBilgileriL : GeriOdemeBilgileri,IBaseHareketEntity
    {

        public long? HesapId { get; set; }
        public string HesapAdi { get; set; }
        public bool Insert { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
    }

    [HighlightedClass]
    public class GeriOdemeBilgileriR
    {
        public DateTime Tarih { get; set; }
        public GeriOdemeHesapTuru HesapTuru { get; set; }
        public string HesapAdi { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }

    }
}
