using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DotNet.ERP.Model.Entities.Base;
namespace DotNet.ERP.Bll.Interfaces
{
    public interface IBaseHareketSelectBll<T>
    {
        IEnumerable<BaseHareketEntity> List(Expression<Func<T, bool>> filter);
    }
}