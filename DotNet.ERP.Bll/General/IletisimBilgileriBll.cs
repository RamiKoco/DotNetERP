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
    public class IletisimBilgileriBll : BaseHareketBll<IletisimBilgileri, ERPContext>, IBaseHareketSelectBll<IletisimBilgileri>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<IletisimBilgileri, bool>> filter)
        {
            return List(filter, x => new IletisimBilgileriL
            {
                Id = x.Id,
                TahakkukId = x.TahakkukId,
                IletisimId = x.IletisimId,
                //TcKimlikNo = x.GenelIletisim.TcKimlikNo,
                //Adi = x.Iletisim.Adi,
                //Soyadi = x.Iletisim.Soyadi,
                //EvTel = x.Iletisim.EvTel,
                //IsTel1 = x.Iletisim.IsTel1,
                //IsTel2 = x.Iletisim.IsTel2,
                //CepTel1 = x.Iletisim.CepTel1,
                //CepTel2 = x.Iletisim.CepTel2,
                //EvAdres = x.Iletisim.EvAdres,
                //EvAdresIlAdi = x.Iletisim.EvAdresIl.Ad,
                //EvAdresIlceAdi = x.Iletisim.EvAdresIlce.Ad,
                //IsAdres = x.Iletisim.IsAdres,
                //IsAdresIlAdi = x.Iletisim.IsAdresIl.Ad,
                //IsAdresIlceAdi = x.Iletisim.IsAdresIlce.Ad,
                YakinlikId = x.YakinlikId,
                YakinlikAdi = x.Yakinlik.YakinlikAdi,
                //MeslekAdi = x.Iletisim.Meslek.Ad,
                //IsyeriAdi = x.Iletisim.Isyeri.IsyeriAdi,
                //GorevAdi = x.Iletisim.Gorev.GorevAdi,
                Veli = x.Veli,
                FaturaAdresi = x.FaturaAdresi

            }).ToList();
        }

    }
}
