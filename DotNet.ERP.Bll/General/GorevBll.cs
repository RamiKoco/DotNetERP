using System.Windows.Forms;
using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;

namespace DotNet.ERP.Bll.General
{
    public class GorevBll:BaseGenelBll<Gorev>,IBaseGenelBll,IBaseCommonBll
    {
        public GorevBll() : base(KartTuru.Gorev) { }
        public GorevBll(Control ctrl) : base(ctrl, KartTuru.Gorev) { }
    }
}
