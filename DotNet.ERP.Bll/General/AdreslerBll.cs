using DotNet.ERP.Common.Enums;
using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
namespace DotNet.ERP.Bll.General
{
    public class AdreslerBll : BaseGenelBll<Adresler>, IBaseGenelBll, IBaseCommonBll
    {
        public AdreslerBll() : base(KartTuru.Adresler) { }
        public AdreslerBll(Control ctrl) : base(ctrl, KartTuru.Adresler) { }
        public override BaseEntity Single(Expression<Func<Adresler, bool>> filter)
        {
            return BaseSingle(filter, x => new AdreslerS
            {
                Id = x.Id,
                Kod = x.Kod,
                KayitTuru = x.KayitTuru,
                Baslik = x.Baslik,
                AdresTipi = x.AdresTipi,
                AdresNotu = x.AdresNotu,
                Adres = x.Adres,
                Aciklama = x.Aciklama,
                PostaKodu = x.PostaKodu,
                Enlem = x.Enlem ?? 0,
                Boylam = x.Boylam ?? 0,
                VarsayilanMi = x.VarsayilanMi,
                VarsayilanFaturaMi = x.VarsayilanFaturaMi,
                VarsayilanSevkiyatMi = x.VarsayilanSevkiyatMi,
                UlkeId = x.UlkeId,
                UlkeAdi = x.Ulke.UlkeAdi,
                IlId = x.IlId,
                IlAdi = x.Il.Ad,
                IlceId = x.IlceId,
                IlceAdi = x.Ilce.Ad,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                AdresTurleriId = x.AdresTurleriId,
                AdresTurleriAdi = x.AdresTurleri.Ad,
                KisiId = x.KisiId,
                PersonelId = x.PersonelId,
                CariId = x.CariId,
                CariSubeId = x.CariSubeId,             
                Durum = x.Durum,
                AnaKayitId = x.AnaKayitId,
                KayitId = x.KayitId,
                KayitHesabiAdi =
                    x.KayitTuru == KayitTuru.Kisi ? x.Kisi.Ad :
                    x.KayitTuru == KayitTuru.Personel ? x.Personel.Ad :
                    x.KayitTuru == KayitTuru.Cari ? x.Cari.Unvan :
                    x.KayitTuru == KayitTuru.CariSube ? x.CariSube.Cari.Unvan :
                    null,

                AnaKayitHesabiAdi = x.KayitTuru == KayitTuru.CariSube ? x.CariSube.Ad : null,
            });
        }
        public override IEnumerable<BaseEntity> List(Expression<Func<Adresler, bool>> filter)
        {
            return BaseList(filter, x => new AdreslerL
            {
                Id = x.Id,
                Kod = x.Kod,
                KayitTuru = x.KayitTuru,
                Baslik = x.Baslik,
                AdresTipi = x.AdresTipi,
                AdresNotu = x.AdresNotu,
                Adres = x.Adres,
                Aciklama = x.Aciklama,
                PostaKodu = x.PostaKodu,
                Enlem = x.Enlem ?? 0,
                Boylam = x.Boylam ?? 0,
                VarsayilanMi = x.VarsayilanMi,
                VarsayilanFaturaMi = x.VarsayilanFaturaMi,
                VarsayilanSevkiyatMi = x.VarsayilanSevkiyatMi,
                UlkeAdi = x.Ulke.UlkeAdi,
                IlAdi = x.Il.Ad,
                IlceAdi = x.Ilce.Ad,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                AdresTurleriAdi = x.AdresTurleri.Ad,
                AnaKayitId = x.AnaKayitId,
                KayitId = x.KayitId,
                KayitHesabiAdi =
                x.KayitTuru == KayitTuru.Kisi ? x.Kisi.Ad :
                x.KayitTuru == KayitTuru.Personel ? x.Personel.Ad :
                x.KayitTuru == KayitTuru.Cari ? x.Cari.Unvan :
                x.KayitTuru == KayitTuru.CariSube ? (x.CariSube != null ? x.CariSube.Ad : null) :
                null,
                AnaKayitHesabiAdi =
                x.KayitTuru == KayitTuru.CariSube ? (x.CariSube != null && x.CariSube.Cari != null ? x.CariSube.Cari.Unvan : null) :
                null,

            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
