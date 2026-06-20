using System.Windows.Forms;
using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;

namespace DotNet.ERP.Bll.General
{
    public class RehberBll:BaseGenelBll<Rehber>,IBaseGenelBll,IBaseCommonBll
    {
        public RehberBll() : base(KartTuru.Rehber) { }
        public RehberBll(Control ctrl) : base(ctrl, KartTuru.Rehber) { }
    }
}
