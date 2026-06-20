using DotNet.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.ERP.Model.Dto
{
    [NotMapped]
    public class RenkS : Entities.Renk
    {
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
    }

    public class RenkL : BaseEntity
    {
        public string RenkAdi { get; set; }
        public string RGB { get; set; }
        public int ForeColor { get; set; }
        public string Aciklama { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }

    }
}
