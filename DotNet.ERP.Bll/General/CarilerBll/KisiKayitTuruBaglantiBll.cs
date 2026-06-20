using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Data.Contexts;
using DotNet.ERP.Model.Dto.CariDto;
using DotNet.ERP.Model.Entities.Base;
using DotNet.ERP.Model.Entities.CariEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DotNet.ERP.Bll.General.CarilerBll
{
    public class KisiKayitTuruBaglantiBll : BaseHareketBll<KisiKayitTuruBaglanti, ERPContext>, IBaseHareketSelectBll<KisiKayitTuruBaglanti>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<KisiKayitTuruBaglanti, bool>> filter)
        {
            using (var context = new ERPContext())
            {
                var list = context.Set<KisiKayitTuruBaglanti>()
                    .Where(filter)
                    .Select(x => new KisiKayitTuruBaglantiL
                    {
                        Id = x.Id,
                        KayitId = x.KayitId,
                        KayitTuru = x.KayitTuru,
                        PozisyonId = x.PozisyonId,
                        PozisyonAdi = x.Pozisyon.Ad,
                        KisiId = x.KisiId,
                        Aciklama = x.Aciklama,
                        KodKisi = x.Kisi.Kod,
                        KisiAdi = x.Kisi != null
                                ? x.Kisi.Ad + " " + (x.Kisi.Soyad ?? "")
                                : null,
                              
                        Kod = context.Cari.Where(c => c.Id == x.KayitId)
                                            .Select(c => c.Kod)
                                            .Concat(context.CariSube.Where(s => s.Id == x.KayitId)
                                            .Select(s => s.Kod)).FirstOrDefault() ?? "Bilinmiyor",
                        KayitHesabi = context.Cari.Where(c => c.Id == x.KayitId)
                                                    .Select(c => c.Unvan)
                                                    .Concat(context.CariSube.Where(s => s.Id == x.KayitId)
                                                    .Select(s => s.Ad)).FirstOrDefault() ?? "Bilinmiyor",
                        AnaKayitHesabi = x.KayitTuru == KayitTuru.CariSube
                                        ? context.CariSube.Where(s => s.Id == x.KayitId)
                                            .Select(s => s.Cari.Unvan)
                                            .FirstOrDefault()
                                        : null,

                    }).ToList();

                return list;
            }
        }
    }
}
