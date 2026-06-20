using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace DotNet.ERP.Bll.General
{
    public class KimlikTuruBll : BaseGenelBll<Model.Entities.KimlikTuru>, IBaseGenelBll, IBaseCommonBll
    {
        public KimlikTuruBll() : base(KartTuru.KimlikTuru) { }
        public KimlikTuruBll(Control ctrl) : base(ctrl, KartTuru.KimlikTuru) { }

        public override BaseEntity Single(Expression<Func<Model.Entities.KimlikTuru, bool>> filter)
        {
            return BaseSingle(filter, x => new Model.Dto.KimlikTuruS
            {

                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                UlkeId = x.UlkeId,
                UlkeAdi = x.Ulke.UlkeAdi,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama,
                KarakterTipi = x.KarakterTipi,
                Uzunluk = x.Uzunluk,
                Durum = x.Durum

            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Model.Entities.KimlikTuru, bool>> filter)
        {
            return BaseList(filter, x => new Model.Dto.KimlikTuruL
            {
                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                UlkeAdi = x.Ulke.UlkeAdi,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama,
                KarakterTipi = x.KarakterTipi,
                Uzunluk = x.Uzunluk
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
