using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Dto.CariDto.CariSubeDto;
using DotNet.ERP.Model.Entities.Base;
using DotNet.ERP.Model.Entities.CariEntity.CariSube;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace DotNet.ERP.Bll.General.CarilerBll.CariSubeBll
{
    public class CariSubeBll : BaseGenelBll<CariSube>, IBaseGenelBll, IBaseCommonBll
    {
        public CariSubeBll() : base(KartTuru.CariSube) { }

        public CariSubeBll(Control ctrl) : base(ctrl, KartTuru.CariSube) { }

        public override BaseEntity Single(Expression<Func<CariSube, bool>> filter)
        {
            return BaseSingle(filter, x => new CariSubeS
            {

                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                CariUnvan=x.Cari.Unvan,
                CariSubeGrubuId = x.CariSubeGrubuId,
                CariSubeGrubuAdi = x.CariSubeGrubu.Ad,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama,
                Durum = x.Durum

            });
        }
        public override IEnumerable<BaseEntity> List(Expression<Func<CariSube, bool>> filter)
        {
            return BaseList(filter, x => new CariSubeL
            {
                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                CariSubeGrubuAdi = x.CariSubeGrubu.Ad,
                CarilerAdi = x.Cari.Unvan,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
