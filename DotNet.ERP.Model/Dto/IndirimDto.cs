using System;
using System.ComponentModel.DataAnnotations.Schema;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.Model.Entities.Base;

namespace DotNet.ERP.Model.Dto
{
    [NotMapped]
    public class IndirimS:Indirim
    {
        public string IndirimTuruAdi { get; set; }

    }
    public class IndirimL : BaseEntity
    {
        public string IndirimAdi { get; set; }
        public long IndirimTuruId { get; set; }
        public string IndirimTuruAdi { get; set; }
        public string Aciklama { get; set; }
    }

}
