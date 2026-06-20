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
    public class KurumTuruBll : BaseGenelBll<KurumTuru>, IBaseGenelBll, IBaseCommonBll
    {
        public KurumTuruBll() : base(KartTuru.KurumTuru) { }
        public KurumTuruBll(Control ctrl) : base(ctrl, KartTuru.KurumTuru) { }
        public override BaseEntity Single(Expression<Func<KurumTuru, bool>> filter)
        {
            return BaseSingle(filter, x => new KurumTuruS
            {
                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                Aciklama = x.Aciklama,
                Durum = x.Durum
            });
        }
        public override IEnumerable<BaseEntity> List(Expression<Func<KurumTuru, bool>> filter)
        {
            return BaseList(filter, x => new KurumTuruL
            {
                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                Aciklama = x.Aciklama

            }).OrderBy(x => x.Kod).ToList();
        }

    }
}
