using DotNet.ERP.Model.Entities.Base;

namespace DotNet.ERP.Bll.Interfaces
{
    public interface IBaseCommonBll
    {
        bool Delete(BaseEntity entity);
    }
}