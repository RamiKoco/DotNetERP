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
    public class AileBilgileriBll : BaseHareketBll<AileBilgileri, ERPContext>,
        IBaseHareketSelectBll<AileBilgileri>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<AileBilgileri, bool>> filter)
        {
            return List(filter, x => new AileBilgileriL
            {
                Id = x.Id,
                TahakkukId = x.TahakkukId,
                AileBilgiId = x.AileBilgiId,
                BilgiAdi = x.AileBilgi.BilgiAdi,
                Aciklama = x.Aciklama

            }).ToList();
        }
    }
}