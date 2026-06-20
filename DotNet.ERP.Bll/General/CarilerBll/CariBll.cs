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
using System.Windows.Forms;

namespace DotNet.ERP.Bll.General.CarilerBll
{
    public class CariBll : BaseGenelBll<Cari>, IBaseGenelBll, IBaseCommonBll
    {
        public CariBll() : base(KartTuru.Cari) { }
        public CariBll(Control ctrl) : base(ctrl, KartTuru.Cari) { }
        public override BaseEntity Single(Expression<Func<Cari, bool>> filter)
        {

            return BaseSingle(filter, x => new CariS
            {

                Id = x.Id,
                Kod = x.Kod,
                KimlikNo = x.KimlikNo,
                Ad = x.Ad,
                Soyad = x.Soyad,                
                Sahis = x.Sahis,
                Unvan = x.Unvan,
                VergiNo = x.VergiNo,             
                VergiDairesiId = x.VergiDairesiId,
                VergiDairesiAdi = x.VergiDairesi.Ad,
                CariGrubuId = x.CariGrubuId,
                CariGrubuAdi = x.CariGrubu.Ad,
                CariTuruId = x.CariTuruId,
                CariTuruAdi = x.CariTuru.Ad,
                EtiketId = x.EtiketId,
                EtiketAdi = x.Etiket.Ad,
                SektorId = x.SektorId,
                SektorAdi = x.Sektor.Ad,
                KayitKaynakId = x.KayitKaynakId,
                KayitKaynakAdi = x.KayitKaynak.Ad,
                KimlikTuruId = x.KimlikTuruId,
                KimlikTuruAdi = x.KimlikTuru.Ad,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                OzelKod3Id = x.OzelKod3Id,
                OzelKod3Adi = x.OzelKod3.OzelKodAdi,
                OzelKod4Id = x.OzelKod4Id,
                OzelKod4Adi = x.OzelKod4.OzelKodAdi,
                OzelKod5Id = x.OzelKod5Id,
                OzelKod5Adi = x.OzelKod5.OzelKodAdi,
                Aciklama = x.Aciklama,
                Durum = x.Durum
            });
        }
        public override IEnumerable<BaseEntity> List(Expression<Func<Cari, bool>> filter)
        {
            return BaseList(filter, x => new CariL
            {
                Id = x.Id,
                Kod = x.Kod,
                KimlikNo = x.KimlikNo,
                Ad = x.Ad,
                Soyad = x.Soyad,
                Sahis = x.Sahis,
                Unvan = x.Unvan,
                VergiNo = x.VergiNo,
                SektorAdi = x.Sektor.Ad,
                CariTuruAdi = x.CariTuru.Ad,
                CariGrubuAdi = x.CariGrubu.Ad,
                EtiketAdi = x.Etiket.Ad,
                VergiDairesiAdi = x.VergiDairesi.Ad,
                KayitKaynakAdi = x.KayitKaynak.Ad,
                KimlikTuruAdi = x.KimlikTuru.Ad,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                OzelKod3Adi = x.OzelKod3.OzelKodAdi,
                OzelKod4Adi = x.OzelKod4.OzelKodAdi,
                OzelKod5Adi = x.OzelKod5.OzelKodAdi,
                Aciklama = x.Aciklama

            }).OrderBy(x => x.Kod).ToList();
        }
        public Model.Entities.KimlikTuru KimlikTuruGetir(long? kimlikTuruId)
        {
            if (kimlikTuruId == null) return null;

            using (var db = new ERPContext())
            {
                return db.KimlikTuru.SingleOrDefault(x => x.Id == kimlikTuruId);
            }
        }
    }
}