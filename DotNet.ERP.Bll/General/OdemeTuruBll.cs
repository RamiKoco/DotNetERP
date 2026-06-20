using System.Windows.Forms;
using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;

namespace DotNet.ERP.Bll.General
{
    public class OdemeTuruBll:BaseGenelBll<OdemeTuru>,IBaseGenelBll,IBaseCommonBll
    {
        public OdemeTuruBll() : base(KartTuru.OdemeTuru) { }

        public OdemeTuruBll(Control ctrl) : base(ctrl, KartTuru.OdemeTuru) { }
    }
}
