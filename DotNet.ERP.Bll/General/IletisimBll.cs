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
    public class IletisimBll : BaseGenelBll<Iletisim>, IBaseGenelBll, IBaseCommonBll
    {
        public IletisimBll() : base(KartTuru.Iletisim) { }
        public IletisimBll(Control ctrl) : base(ctrl, KartTuru.Iletisim) { }
        public override BaseEntity Single(Expression<Func<Iletisim, bool>> filter)
        {
            return BaseSingle(filter, x => new IletisimS
            {

                Id = x.Id,
                Kod = x.Kod,
                KayitTuru = x.KayitTuru,
                IletisimTuru = x.IletisimTuru,
                IzinDurumu = x.IzinDurumu,
                IletisimKanalTipi = x.IletisimKanalTipi,
                Kanallar = x.Kanallar,
                Arama = x.Arama,
                Sms = x.Sms,
                Whatsapp = x.Whatsapp,
                EPBool = x.EPBool,
                Baslik = x.Baslik,
                UlkeKodu = x.UlkeKodu,
                Numara = x.Numara,
                DahiliNo = x.DahiliNo,
                EPosta = x.EPosta,
                KullaniciAdi = x.KullaniciAdi,
                SosyalMedyaUrl = x.SosyalMedyaUrl,
                SIPKullaniciAdi = x.SIPKullaniciAdi,
                SIPServer = x.SIPServer,               
                Oncelik = x.Oncelik,
                VoipMi = x.VoipMi,
                KisiId = x.KisiId,
                IlgiliKisiId = x.IlgiliKisiId,
                IlgiliKisiAdi = x.IlgiliKisi.Ad+" "+ x.IlgiliKisi.Soyad,
                PersonelId = x.PersonelId,
                //MeslekId = x.MeslekId,
                CariId = x.CariId,
                CariSubeId = x.CariSubeId,
                SosyalMedyaPlatformuId = x.SosyalMedyaPlatformuId,
                SosyalMedyaPlatformuAdi = x.SosyalMedyaPlatformu.Ad,
                IzinTarihi = x.IzinTarihi,
                Web = x.Web,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama,
                Durum = x.Durum,
                AnaKayitId = x.AnaKayitId,
                KayitId = x.KayitId,
                KayitHesabiAdi =
                    x.KayitTuru == KayitTuru.Kisi ? x.Kisi.Ad +" "+ x.Kisi.Soyad:
                    x.KayitTuru == KayitTuru.Personel ? x.Personel.Ad + " " + x.Personel.Soyad :
                    x.KayitTuru == KayitTuru.Cari ? x.Cari.Unvan :
                    x.KayitTuru == KayitTuru.CariSube ? x.CariSube.Cari.Unvan :
                    null,

                // Şube adı ayrı alınıyor
                AnaKayitHesabiAdi = x.KayitTuru == KayitTuru.CariSube ? x.CariSube.Ad : null,
            });
        }
        public override IEnumerable<BaseEntity> List(Expression<Func<Iletisim, bool>> filter)
        {
            return BaseList(filter, x => new IletisimL
            {
                Id = x.Id,
                Kod = x.Kod,
                Baslik = x.Baslik,
                KayitTuru = x.KayitTuru,
                IletisimTuru = x.IletisimTuru,
                UlkeKodu = x.UlkeKodu,
                Numara = x.Numara,
                DahiliNo = x.DahiliNo,
                EPosta = x.EPosta,
                KullaniciAdi = x.KullaniciAdi,
                SosyalMedyaUrl = x.SosyalMedyaUrl,
                SIPKullaniciAdi = x.SIPKullaniciAdi,
                SIPServer = x.SIPServer,
                //Ilgili = x.Ilgili,                
                IlgiliKisiAdi = x.IlgiliKisi.Ad + " " + x.IlgiliKisi.Soyad,
                Oncelik = x.Oncelik,
                VoipMi = x.VoipMi,
                IzinDurumu = x.IzinDurumu,
                IletisimKanalTipi = x.IletisimKanalTipi,
                Kanallar = x.Kanallar,
                Arama = x.Arama,
                Sms = x.Sms,
                Whatsapp = x.Whatsapp,
                EPBool = x.EPBool,
                SosyalMedyaPlatformuAdi = x.SosyalMedyaPlatformu.Ad,
                IzinTarihi = x.IzinTarihi,
                Web = x.Web,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,                
                AnaKayitId = x.AnaKayitId,
                KayitId = x.KayitId,
                KayitHesabiAdi =
                x.KayitTuru == KayitTuru.Kisi ? x.Kisi.Ad + " " + x.Kisi.Soyad :
                x.KayitTuru == KayitTuru.Personel ? x.Personel.Ad + " " + x.Personel.Soyad :
                x.KayitTuru == KayitTuru.Cari ? x.Cari.Unvan :
                x.KayitTuru == KayitTuru.CariSube ? (x.CariSube != null ? x.CariSube.Ad : null) :
                null,
                AnaKayitHesabiAdi =
                x.KayitTuru == KayitTuru.CariSube ? (x.CariSube != null && x.CariSube.Cari != null ? x.CariSube.Cari.Unvan : null) :             
                null,
                Aciklama = x.Aciklama
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
