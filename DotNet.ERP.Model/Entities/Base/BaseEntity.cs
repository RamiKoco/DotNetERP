using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DotNet.ERP.Model.Attributes;
using DotNet.ERP.Model.Entities.Base.Interfaces;
namespace DotNet.ERP.Model.Entities.Base
{
   public class BaseEntity:IBaseEntity
    {
        [Column(Order = 0),Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [Column(Order = 1),Required,StringLength(30),Kod("Kod","txtKod"),ZorunluAlan("Kod","txtKod")]
        public virtual string Kod { get; set; }
    }
}