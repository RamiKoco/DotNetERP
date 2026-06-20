using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Data.Contexts;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.Model.Entities.Base;

namespace DotNet.ERP.Bll.General
{
    public class GeriOdemeBilgileriBll : BaseHareketBll<GeriOdemeBilgileri, ERPContext>, IBaseHareketSelectBll<GeriOdemeBilgileri>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<GeriOdemeBilgileri, bool>> filter)
        {
            return List(filter, x => new GeriOdemeBilgileriL
            {
                Id = x.Id,
                TahakkukId = x.TahakkukId,
                Tarih = x.Tarih,
                HesapTuru = x.HesapTuru,
                HesapId = x.HesapTuru == GeriOdemeHesapTuru.Kasa  ? x.KasaId : x.BankaHesapId,
                HesapAdi = x.HesapTuru == GeriOdemeHesapTuru.Kasa ? x.Kasa.KasaAdi : x.BankaHesap.HesapAdi,
                BankaHesapId = x.BankaHesapId,
                KasaId = x.KasaId,
                Tutar = x.Tutar,
                Aciklama = x.Aciklama,

            }).ToList();

        }
    }
}
