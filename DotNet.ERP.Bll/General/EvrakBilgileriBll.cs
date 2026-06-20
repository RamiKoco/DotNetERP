using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Data.Contexts;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.Model.Entities.Base;

namespace DotNet.ERP.Bll.General
{
    public class EvrakBilgileriBll : BaseHareketBll<EvrakBilgileri, ERPContext>, IBaseHareketSelectBll<EvrakBilgileri>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<EvrakBilgileri, bool>> filter)
        {
            return List(filter, x => new EvrakBilgileriL
            {
                Id = x.Id,
                TahakkukId = x.TahakkukId,
                EvrakId = x.EvrakId,
                Kod = x.Evrak.Kod,
                EvrakAdi = x.Evrak.EvrakAdi

            }).ToList();
        }
    }
}