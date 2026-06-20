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
    public class UyrukBll : BaseGenelBll<Model.Entities.Uyruk>, IBaseGenelBll, IBaseCommonBll
    {
        public UyrukBll() : base(KartTuru.Uyruk) { }
        public UyrukBll(Control ctrl) : base(ctrl, KartTuru.Uyruk) { }

        public override BaseEntity Single(Expression<Func<Model.Entities.Uyruk, bool>> filter)
        {
            return BaseSingle(filter, x => new Model.Dto.UyrukS
            {

                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                UlkeId = x.UlkeId,
                UlkeAdi = x.Ulke.UlkeAdi,
                Aciklama = x.Aciklama,
                Durum = x.Durum
            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Model.Entities.Uyruk, bool>> filter)
        {
            return BaseList(filter, x => new Model.Dto.UyrukL
            {
                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                UlkeAdi = x.Ulke.UlkeAdi,
                Aciklama = x.Aciklama

            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
