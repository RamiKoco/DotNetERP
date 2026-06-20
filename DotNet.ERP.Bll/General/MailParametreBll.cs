using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Model.Entities;
using System.Windows.Forms;

namespace DotNet.ERP.Bll.General
{
    public class MailParametreBll : BaseGenelBll<MailParametre>, IBaseGenelBll, IBaseCommonBll
    {
        public MailParametreBll() { }
        public MailParametreBll(Control ctrl) : base(ctrl) { }
    }
}