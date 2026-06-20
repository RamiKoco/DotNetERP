using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Data.Contexts;
using DotNet.ERP.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DotNet.ERP.Bll.General
{
    public class SektorBll : BaseGenelBll<Sektor>, IBaseGenelBll, IBaseCommonBll
    {
        public SektorBll() : base(KartTuru.Sektor) { }
        public SektorBll(Control ctrl) : base(ctrl, KartTuru.Sektor) { }

        public List<Sektor> ListSimple()
        {
            using (var context = new ERPContext())
            {
                return context.Sektor
                              .OrderBy(x => x.Ad)
                              .ToList();
            }
        }
    }
}
