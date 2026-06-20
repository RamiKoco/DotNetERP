using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.Model.Entities.Base;
using System.Linq.Expressions;
using System.Windows.Forms;
using System;

namespace DotNet.ERP.Bll.General
{
    public class KurumBilgileriBll : BaseGenelBll<KurumBilgileri>, IBaseGenelBll, IBaseCommonBll
    {
        public KurumBilgileriBll(Control ctrl) : base(ctrl) { }

        public override BaseEntity Single(Expression<Func<KurumBilgileri, bool>> filter)
        {
            return BaseSingle(filter, x => new KurumBilgileriS
            {
                Id = x.Id,
                Kod = x.Kod,
                KurumAdi = x.KurumAdi,
                VergiDairesiId = x.VergiDairesiId,
                VergiDairesiAdi = x.VergiDairesi.Ad,
                VergiNo = x.VergiNo,
                //IlId = x.IlId,
                //IlAdi = x.Il.Ad,
                //IlceId = x.IlceId,
                //IlceAdi = x.Ilce.Ad vv bbb 

            });
        }
    }
}
