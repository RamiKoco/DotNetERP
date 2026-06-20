using System.Windows.Forms;
using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;

namespace DotNet.ERP.Bll.General
{
    public class BankaSubeBll:BaseGenelBll<BankaSube>,IBaseCommonBll
    {
        public BankaSubeBll() : base(KartTuru.BankaSube) { }
        public BankaSubeBll(Control ctrl) : base(ctrl, KartTuru.BankaSube) { }
    }
}
