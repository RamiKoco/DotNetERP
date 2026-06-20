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
    public class PozisyonBll : BaseGenelBll<Model.Entities.Pozisyon>, IBaseGenelBll, IBaseCommonBll
    {
        public PozisyonBll() : base(KartTuru.Pozisyon) { }
        public PozisyonBll(Control ctrl) : base(ctrl, KartTuru.Pozisyon) { }

        public override BaseEntity Single(Expression<Func<Model.Entities.Pozisyon, bool>> filter)
        {
            return BaseSingle(filter, x => new Model.Dto.PozisyonS
            {

                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,              
                Aciklama = x.Aciklama,
                Durum = x.Durum

            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Model.Entities.Pozisyon, bool>> filter)
        {
            return BaseList(filter, x => new Model.Dto.PozisyonL
            {
                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama

            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
