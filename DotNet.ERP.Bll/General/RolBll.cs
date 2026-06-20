using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Model.Entities;
using System.Windows.Forms;
using DotNet.ERP.Common.Enums;

namespace DotNet.ERP.Bll.General
{
    public class RolBll : BaseGenelBll<Rol>, IBaseGenelBll, IBaseCommonBll
    {
        public RolBll() : base(KartTuru.Rol) { }
        public RolBll(Control ctrl) : base(ctrl,KartTuru.Rol) { }
    }
}
