using DotNet.ERP.Common.Enums;
using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace DotNet.ERP.Bll.General
{
    public class EtiketBll : BaseGenelBll<Model.Entities.Etiket>, IBaseGenelBll, IBaseCommonBll
    {
        public EtiketBll() : base(KartTuru.Etiket) { }
        public EtiketBll(Control ctrl) : base(ctrl, KartTuru.Etiket) { }

        public override BaseEntity Single(Expression<Func<Model.Entities.Etiket, bool>> filter)
        {
            return BaseSingle(filter, x => new Model.Dto.EtiketS
            {
                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                KayitTuru = x.KayitTuru,
                Aciklama = x.Aciklama,
                RenkId = x.RenkId,
                RenkAdi = x.Renk.RenkAdi,
                RenkRGB = x.Renk != null ? x.Renk.RGB : null,
                RenkForeColor = x.Renk != null ? x.Renk.ForeColor : (int?)null,
                YaziRgbKodu = x.YaziRgbKodu,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Durum = x.Durum
            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Model.Entities.Etiket, bool>> filter)
        {
            return BaseList(filter, x => new Model.Dto.EtiketL
            {
                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                KayitTuru =(x.KayitTuru ?? 0),
                Aciklama = x.Aciklama,
                RenkAdi = x.Renk.RenkAdi,
                RenkRGB = x.Renk != null ? x.Renk.RGB : null,
                RenkForeColor = x.Renk != null ? x.Renk.ForeColor : (int?)null,
                YaziRgbKodu = x.YaziRgbKodu,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,

            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
