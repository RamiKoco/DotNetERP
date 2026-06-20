using DotNet.ERP.Model.Entities.Base;
using DotNet.ERP.Model.Entities.CariEntity.CariSube;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.ERP.Model.Dto.CariDto.CariSubeDto
{
    [NotMapped]
    public class CariSubeS : CariSube
    {
        public string CariSubeGrubuAdi { get; set; }
        public string CarilerAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public string CariUnvan { get; set; }
    }

    public class CariSubeL : BaseEntity
    {
        public string Ad { get; set; }
        public string CariSubeGrubuAdi { get; set; }
        public string Aciklama { get; set; }
        public string CarilerAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
    }
}
