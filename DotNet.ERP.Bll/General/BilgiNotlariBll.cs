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
    public class YorumlarBll : BaseHareketBll<Yorumlar, ERPContext>, IBaseHareketSelectBll<Yorumlar>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<Yorumlar, bool>> filter)
        {
            return List(filter, x => new YorumlarL
            {
                Id = x.Id,
                TahakkukId = x.TahakkukId,
                KisiId = x.KisiId,
                PersonelId=x.PersonelId,
                CarilerId = x.CarilerId,
                CariSubelerId = x.CariSubelerId,
                Tarih = x.Tarih,
                Yorum = x.Yorum

            }).ToList();
        }

    }
}
