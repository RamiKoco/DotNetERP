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
    public class PromosyonBilgileriBll : BaseHareketBll<PromosyonBilgileri, ERPContext>, IBaseHareketSelectBll<PromosyonBilgileri>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<PromosyonBilgileri, bool>> filter)
        {
            return List(filter, x => new PromosyonBilgileriL
            {
                Id = x.Id,
                TahakkukId = x.TahakkukId,
                PromosyonId = x.PromosyonId,
                Kod = x.Promosyon.Kod,
                PromosyonAdi = x.Promosyon.PromosyonAdi

            }).ToList();
        }
    }
}
