using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities.Base;
using DotNet.ERP.Model.Entities.KisiEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace DotNet.ERP.Bll.General.KisiBll
{
    public class KisiBll : BaseGenelBll<Kisi>, IBaseGenelBll, IBaseCommonBll
    {
        public KisiBll() : base(KartTuru.Kisi) { }
        public KisiBll(Control ctrl) : base(ctrl, KartTuru.Kisi) { }
        public override BaseEntity Single(Expression<Func<Kisi, bool>> filter)
        {
            return BaseSingle(filter, x => new Model.Dto.KisiDto.KisiS
            {
                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                Soyad = x.Soyad,
                Cinsiyet = x.Cinsiyet,
                KayitTuru = x.KayitTuru,
                DogumTarihi = x.DogumTarihi,
                Aciklama = x.Aciklama,
                PersonelId = x.PersonelId,
                PersonelAdi = x.Personel.Ad,
                KayitKaynakId = x.KayitKaynakId,
                KayitKaynakAdi = x.KayitKaynak.Ad,
                KisiGrubuId = x.KisiGrubuId,
                KisiGrubuAdi = x.KisiGrubu.Ad,
                EtiketId = x.EtiketId,
                EtiketAdi = x.Etiket.Ad,
                MeslekId = x.MeslekId,
                MeslekAdi = x.Meslek.Ad,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Durum = x.Durum
            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Kisi, bool>> filter)
        {
            return BaseList(filter, x => new Model.Dto.KisiDto.KisiL
            {
                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                Soyad = x.Soyad,
                Cinsiyet = x.Cinsiyet,
                DogumTarihi = x.DogumTarihi,
                KayitTuru = x.KayitTuru,
                EtiketAdi = x.Etiket.Ad,
                Aciklama = x.Aciklama,
                PersonelAdi = x.Personel.Ad,
                KayitKaynakAdi = x.KayitKaynak.Ad,
                MeslekAdi = x.Meslek.Ad,
                KisiGrubuAdi = x.KisiGrubu.Ad,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
