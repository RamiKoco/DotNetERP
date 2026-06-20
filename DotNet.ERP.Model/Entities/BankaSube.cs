using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DotNet.ERP.Model.Attributes;
using DotNet.ERP.Model.Entities.Base;

namespace DotNet.ERP.Model.Entities
{
    public class BankaSube:BaseEntityDurum
    {

        [Index("IX_Kod", IsUnique = false)]
        public override string Kod { get; set; }

        [Required, StringLength(50), ZorunluAlan("Şube Adı", "txtSubeAdi")]
        public string SubeAdi { get; set; }
        public long BankaId { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }
        public Banka Banka { get; set; }

    }
}