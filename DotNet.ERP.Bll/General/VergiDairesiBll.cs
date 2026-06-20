using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
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
    public class VergiDairesiBll : BaseGenelBll<VergiDairesi>, IBaseGenelBll, IBaseCommonBll
    {
        public VergiDairesiBll() : base(KartTuru.VergiDairesi) { }
        public VergiDairesiBll(Control ctrl) : base(ctrl, KartTuru.VergiDairesi) { }

        public override BaseEntity Single(Expression<Func<VergiDairesi, bool>> filter)
        {
            return BaseSingle(filter, x => new VergiDairesiS
            {
                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                IlId = x.IlId,
                IlAdi = x.Il.Ad,
                Aciklama = x.Aciklama,
                Durum = x.Durum

            });
        }
        public override IEnumerable<BaseEntity> List(Expression<Func<VergiDairesi, bool>> filter)
        {
            return BaseList(filter, x => new VergiDairesiL
            {
                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                IlAdi = x.Il.Ad,
                Aciklama = x.Aciklama
            }).OrderBy(x => x.Kod).ToList();
        }

    }
}
