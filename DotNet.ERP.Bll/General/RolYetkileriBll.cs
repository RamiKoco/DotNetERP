using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Data.Contexts;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities.Base;
using DotNet.ERP.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DotNet.ERP.Common.Functions;

namespace DotNet.ERP.Bll.General
{
    public class RolYetkileriBll : BaseHareketBll<RolYetkileri, ERPContext>, IBaseHareketSelectBll<RolYetkileri>
    {
        public BaseHareketEntity Single(Expression<Func<RolYetkileri, bool>> filter)
        {
            return Single(filter, x => x);
          
        }
        public IEnumerable<BaseHareketEntity> List(Expression<Func<RolYetkileri, bool>> filter)
        {
            return List(filter, x => new RolYetkileriL
            {
                Id = x.Id,
                RolId = x.RolId,
                KartTuru = x.KartTuru,
                Gorebilir = x.Gorebilir,
                Ekleyebilir = x.Ekleyebilir,
                Degistirebilir = x.Degistirebilir,
                Silebilir = x.Silebilir

            }).AsEnumerable().OrderBy(x=> x.KartTuru.ToName()).ToList();
        }
    }
}

