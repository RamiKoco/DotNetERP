using System.Windows.Forms;
using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;

namespace DotNet.ERP.Bll.General
{
    public class OzelKodBll:BaseGenelBll<OzelKod>,IBaseCommonBll
    {
        public OzelKodBll() : base(KartTuru.OzelKod) { }

        public OzelKodBll(Control ctrl) : base(ctrl, KartTuru.OzelKod) { }
    }
}
