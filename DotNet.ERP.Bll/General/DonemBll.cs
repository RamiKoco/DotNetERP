using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using System.Windows.Forms;

namespace DotNet.ERP.Bll.General
{
    public class DonemBll : BaseGenelBll<Donem>, IBaseGenelBll, IBaseCommonBll
    {
        public DonemBll() : base(KartTuru.Donem) { }
        public DonemBll(Control ctrl) : base(ctrl, KartTuru.Donem) { }
    }
}