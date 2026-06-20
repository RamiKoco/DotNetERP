using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using System.Windows.Forms;
using DotNet.ERP.Model.Entities;

namespace DotNet.ERP.Bll.General
{
    public class EvrakBll : BaseGenelBll<Evrak>, IBaseCommonBll
    {
        public EvrakBll() : base(KartTuru.Evrak) { }
        public EvrakBll(Control ctrl) : base(ctrl, KartTuru.Evrak) { }
    }
}
