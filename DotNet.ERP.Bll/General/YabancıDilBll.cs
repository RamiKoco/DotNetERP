using System.Windows.Forms;
using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;

namespace DotNet.ERP.Bll.General
{
    public class YabancıDilBll:BaseGenelBll<YabanciDil>,IBaseGenelBll,IBaseCommonBll
    {
        public YabancıDilBll() : base(KartTuru.YabanciDil) { }

        public YabancıDilBll(Control ctrl) : base(ctrl, KartTuru.YabanciDil) { }
    }
}
