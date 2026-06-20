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
    public class SinavBilgileriBll : BaseHareketBll<SinavBilgileri, ERPContext>, IBaseHareketSelectBll<SinavBilgileri>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<SinavBilgileri, bool>> filter)
        {
            return List(filter, x => new SinavBilgileriL
            {
                Id = x.Id,
                TahakkukId = x.TahakkukId,
                Tarih = x.Tarih,
                SinavAdi = x.SinavAdi,
                PuanTuru = x.PuanTuru,
                Puan = x.Puan,
                Sira = x.Sira,
                Yuzde = x.Yuzde
            }).ToList();

        }
    }
}
