using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Data.Contexts;
using DotNet.ERP.Model.Dto.PersonelDto;
using DotNet.ERP.Model.Entities.Base;
using DotNet.ERP.Model.Entities.PersonelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DotNet.ERP.Bll.General.PersonelBll
{
    public class PersonelBelgeBll : BaseHareketBll<PersonelBelge, ERPContext>, IBaseHareketSelectBll<PersonelBelge>
    {

        public IEnumerable<BaseHareketEntity> List(Expression<Func<PersonelBelge, bool>> filter)
        {
            return List(filter, x => new PersonelBelgeL
            {
                Id = x.Id,
                PersonelId = x.PersonelId,
                BelgeNo = x.BelgeNo,
                VerilisTarihi = x.VerilisTarihi,
                GecerlilikTarihi = x.GecerlilikTarihi,
                BelgeTuruId = x.BelgeTuruId,
                BelgeAdi = x.BelgeTuru.Ad,
                KurumlarId = x.KurumlarId,
                KurumAdi = x.Kurumlar.Ad,
                Aciklama = x.Aciklama,
            }).ToList();
        }
    }
}