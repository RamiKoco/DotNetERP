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
    public class SosyalMedyaPlatformuBll : BaseGenelBll<Model.Entities.SosyalMedyaPlatformu>, IBaseGenelBll, IBaseCommonBll
    {
        public SosyalMedyaPlatformuBll() : base(KartTuru.SosyalMedyaPlatformu) { }
        public SosyalMedyaPlatformuBll(Control ctrl) : base(ctrl, KartTuru.SosyalMedyaPlatformu) { }

        public override BaseEntity Single(Expression<Func<Model.Entities.SosyalMedyaPlatformu, bool>> filter)
        {
            return BaseSingle(filter, x => new Model.Dto.SosyalMedyaPlatformuS
            {
                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                Aciklama = x.Aciklama,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Durum = x.Durum
            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Model.Entities.SosyalMedyaPlatformu, bool>> filter)
        {
            return BaseList(filter, x => new Model.Dto.SosyalMedyaPlatformuL
            {
                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                Aciklama = x.Aciklama,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi

            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
