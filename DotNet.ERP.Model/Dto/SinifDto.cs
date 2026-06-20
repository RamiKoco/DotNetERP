using System.ComponentModel.DataAnnotations.Schema;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.Model.Entities.Base;

namespace DotNet.ERP.Model.Dto
{
    [NotMapped]
    public class SinifS:Sinif
    {
        public string GrupAdi { get; set; }
    }
    public class SinifL : BaseEntity
    {
        public string SinifAdi { get; set; }
        public string GrupAdi { get; set; }
        public int HedefOgrenciSayisi { get; set; }
        public decimal HedefCiro { get; set; }
        public string Aciklama { get; set; }
    }
}
