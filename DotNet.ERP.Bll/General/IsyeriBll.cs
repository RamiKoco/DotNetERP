using System.Windows.Forms;
using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;

namespace DotNet.ERP.Bll.General
{
    public class IsyeriBll:BaseGenelBll<Isyeri>,IBaseGenelBll,IBaseCommonBll
    {
        public IsyeriBll() : base(KartTuru.Isyeri) { }
        public IsyeriBll(Control ctrl) : base(ctrl, KartTuru.Isyeri) { }
    }
}