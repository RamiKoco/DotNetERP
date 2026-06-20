using System;
using System.ComponentModel.DataAnnotations.Schema;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.Model.Entities.Base;

namespace DotNet.ERP.Model.Dto
{
    [NotMapped]
    public class HizmetS:Hizmet
    {
        public string HizmetTuruAdi { get; set; }
    }

    public class HizmetL : BaseEntity
    {
        public string HizmetAdi { get; set; }
        public long HizmetTuruId { get; set; }
        public string HizmetTuruAdi { get; set; }
        public HizmetTipi HizmetTipi { get; set; }
        public DateTime BaslamaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public decimal Ucret { get; set; }
        public string Aciklama { get; set; }
    }
}
