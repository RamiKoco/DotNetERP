using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Data.Contexts;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities.Base;
using DotNet.ERP.Model.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Linq;
using DotNet.ERP.Common.Enums;

namespace DotNet.ERP.Bll.General
{
    public class KullaniciBirimYetkileriBll : BaseHareketBll<KullaniciBirimYetkileri, ERPContext>, IBaseHareketSelectBll<KullaniciBirimYetkileri>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<KullaniciBirimYetkileri, bool>> filter)
        {
            return List(filter, x => new KullaniciBirimYetkileriL
            {
                Id = x.Id,
                Kod = x.KartTuru == KartTuru.Sube ? x.Sube.Kod : x.Donem.Kod,
                KartTuru = x.KartTuru,
                SubeId = x.SubeId,
                SubeAdi = x.Sube.SubeAdi,
                DonemId = x.DonemId,
                DonemAdi = x.Donem.DonemAdi
            }).ToList();
        }

    }
}