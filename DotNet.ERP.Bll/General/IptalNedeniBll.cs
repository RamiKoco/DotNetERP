using System.Windows.Forms;
using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;

namespace DotNet.ERP.Bll.General
{
    public class IptalNedeniBll:BaseGenelBll<IptalNedeni>,IBaseGenelBll,IBaseCommonBll
    {
        public IptalNedeniBll() : base(KartTuru.IptalNedeni) { }
        public IptalNedeniBll(Control ctrl) : base(ctrl, KartTuru.IptalNedeni) { }
    }
}
