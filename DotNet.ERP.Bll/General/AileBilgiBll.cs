using System.Windows.Forms;
using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;

namespace DotNet.ERP.Bll.General
{
    public class AileBilgiBll:BaseGenelBll<AileBilgi>,IBaseGenelBll,IBaseCommonBll
    {
        public AileBilgiBll() : base(KartTuru.AileBilgi) { }
        public AileBilgiBll(Control ctrl) : base(ctrl, KartTuru.AileBilgi) { }
    }
}