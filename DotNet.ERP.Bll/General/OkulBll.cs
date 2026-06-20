using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;
using DotNet.ERP.Bll.Base;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.Model.Entities.Base;
using DotNet.ERP.Common.Enums;
using System.Linq;
using DotNet.ERP.Bll.Interfaces;

namespace DotNet.ERP.Bll.General
{
    public class OkulBll : BaseGenelBll<Okul>, IBaseGenelBll,IBaseCommonBll
    {
        public OkulBll() : base(KartTuru.Okul) { }

        public OkulBll(Control ctrl) : base(ctrl,KartTuru.Okul) { }


        public override BaseEntity Single(Expression<Func<Okul, bool>> filter)
        {
            return BaseSingle(filter, x => new OkulS
            {
                Id = x.Id,
                Kod = x.Kod,
                OkulAdi = x.OkulAdi,
                IlId = x.IlId,
                IlAdi = x.Il.Ad,
                IlceId = x.IlceId,
                IlceAdi = x.Ilce.Ad,
                Aciklama = x.Aciklama,
                Durum = x.Durum
            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Okul, bool>> filter)
        {
            return BaseList(filter, x => new OkulL
            {
                Id = x.Id,
                Kod = x.Kod,
                OkulAdi = x.OkulAdi,
                IlAdi = x.Il.Ad,
                IlceAdi = x.Ilce.Ad,
                Aciklama = x.Aciklama
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
