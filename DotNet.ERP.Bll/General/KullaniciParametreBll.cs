using System.Linq.Expressions;
using System;
using System.Windows.Forms;
using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.Model.Entities.Base;

namespace DotNet.ERP.Bll.General
{
    public class KullaniciParametreBll : BaseGenelBll<KullaniciParametre> , IBaseGenelBll, IBaseCommonBll
    {
        public KullaniciParametreBll() : base(KartTuru.KullaniciParametre) { }

        public KullaniciParametreBll(Control ctrl) : base(ctrl, KartTuru.KullaniciParametre) { }

        public override BaseEntity Single(Expression<Func<KullaniciParametre, bool>> filter)
        {
            return BaseSingle(filter, x => new KullaniciParametreS
            {
                Id = x.Id,
                Kod = x.Kod,
                KullaniciId = x.KullaniciId,
                DefaultAvukatHesapId = x.DefaultAvukatHesapId,
                DefaultAvukatHesapAdi = x.DefaultAvukatHesap.AdiSoyadi,
                DefaultBankaHesapId = x.DefaultBankaHesapId,
                DefaultBankaHesapAdi = x.DefaultBankaHesap.HesapAdi,
                DefaultKasaHesapId = x.DefaultKasaHesapId,
                DefaultKasaHesapAdi = x.DefaultKasaHesap.KasaAdi,
                RaporlariOnayAlmadanKapat = x.RaporlariOnayAlmadanKapat,
                TableViewCaptionForeColor = x.TableViewCaptionForeColor,
                TableColumnHeaderForeColor = x.TableColumnHeaderForeColor,
                TableBandPanelForeColor = x.TableBandPanelForeColor,
                ArkaPlanResim = x.ArkaPlanResim,

            });
        }

    }
}
