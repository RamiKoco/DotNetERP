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
    public class IndiriminUygulanacagiHizmetBilgileriBll:BaseHareketBll<IndiriminUygulanacagiHizmetBilgileri,ERPContext>,IBaseHareketSelectBll<IndiriminUygulanacagiHizmetBilgileri>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<IndiriminUygulanacagiHizmetBilgileri, bool>> filter)
        {
            return List(filter, x => new IndiriminUygulanacagiHizmetBilgileriL
            {
                Id = x.Id,
                IndirimId = x.IndirimId,
                HizmetId = x.HizmetId,
                HizmetAdi = x.Hizmet.HizmetAdi,
                IndirimTutari = x.IndirimTutari,
                IndirimOrani = x.IndirimOrani,
                SubeId = x.SubeId,
                DonemId = x.DonemId

            }).ToList();
        }
    }
}
