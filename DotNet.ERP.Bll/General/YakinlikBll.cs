using System.Windows.Forms;
using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;

namespace DotNet.ERP.Bll.General
{
    public class YakinlikBll:BaseGenelBll<Yakinlik>,IBaseGenelBll,IBaseCommonBll
    {
        public YakinlikBll() : base(KartTuru.Yakinlik) { }
        public YakinlikBll(Control ctrl) : base(ctrl, KartTuru.Yakinlik) { }
    }
}
