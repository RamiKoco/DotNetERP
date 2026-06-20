using System;
using System.Linq.Expressions;
using DotNet.ERP.Model.Entities.Base;

namespace DotNet.ERP.UI.Win.Forms.Functions
{
   public class FilterFunctions
    {

        public static Expression<Func<T, bool>> Filter<T>(bool aktifKartlariGoster) where T : BaseEntityDurum
        {
            return x => x.Durum == aktifKartlariGoster;
        }

        public static Expression<Func<T, bool>> Filter<T>(long id) where T : BaseEntity
        {
            return x => x.Id == id;
        }
    }
}
