using DotNet.ERP.Model.Entities.Base;
namespace DotNet.ERP.Bll.Interfaces
{
   public interface IBaseGenelBll
   {
       bool Insert(BaseEntity entity);
       bool Update(BaseEntity oldEntity, BaseEntity currentEntity);
       string YeniKodVer();
   }
}