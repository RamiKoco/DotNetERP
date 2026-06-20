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
    public class RenkBll : BaseGenelBll<Model.Entities.Renk>, IBaseGenelBll, IBaseCommonBll
    {
        public RenkBll() : base(KartTuru.Renk) { }
        public RenkBll(Control ctrl) : base(ctrl, KartTuru.Renk) { }

        public override BaseEntity Single(Expression<Func<Model.Entities.Renk, bool>> filter)
        {
            return BaseSingle(filter, x => new Model.Dto.RenkS
            {
                Id = x.Id,
                Kod = x.Kod,
                RenkAdi = x.RenkAdi,
                RGB = x.RGB,
                ForeColor = x.ForeColor,
                Aciklama = x.Aciklama,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Durum = x.Durum
            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Model.Entities.Renk, bool>> filter)
        {
            return BaseList(filter, x => new Model.Dto.RenkL
            {
                Id = x.Id,
                Kod = x.Kod,
                RenkAdi = x.RenkAdi,
                RGB = x.RGB,
                ForeColor = x.ForeColor,
                Aciklama = x.Aciklama,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,

            }).OrderBy(x => x.Kod).ToList();
        }

    }
}
