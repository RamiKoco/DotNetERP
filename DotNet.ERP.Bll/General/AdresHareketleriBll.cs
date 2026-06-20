using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Data.Contexts;
using DotNet.ERP.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DotNet.ERP.Bll.General
{
    public class AdresHareketleriBll : BaseHareketBll<Model.Entities.AdresHareketleri, ERPContext>, IBaseHareketSelectBll<Model.Entities.AdresHareketleri>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<Model.Entities.AdresHareketleri, bool>> filter)
        {
            return List(filter, x => new Model.Dto.AdresHareketleriL
            {
                Id = x.Id,
                KisiId = (long)x.GenelAdres.KayitId,
                PersonelId = (long)x.GenelAdres.PersonelId,
                GenelAdresId = x.GenelAdresId,
                Baslik = x.GenelAdres.Baslik,
                KayitTuru = x.GenelAdres.KayitTuru,
                AdresTipi = x.GenelAdres.AdresTipi,
                AdresNotu = x.GenelAdres.AdresNotu,
                Adres = x.GenelAdres.Adres,                
                PostaKodu = x.GenelAdres.PostaKodu,
                Enlem = x.GenelAdres.Enlem ?? 0,
                Boylam = x.GenelAdres.Boylam ?? 0,               
                UlkeAdi = x.GenelAdres.Ulke.UlkeAdi,
                IlAdi = x.GenelAdres.Il.Ad,
                IlceAdi = x.GenelAdres.Ilce.Ad,                
                AdresTurleriAdi = x.GenelAdres.AdresTurleri.Ad

            }).ToList();
        }
    }
}
