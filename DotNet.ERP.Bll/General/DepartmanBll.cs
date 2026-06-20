using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using System.Windows.Forms;

namespace DotNet.ERP.Bll.General
{
    public class DepartmanBll : BaseGenelBll<Model.Entities.Departman>, IBaseGenelBll, IBaseCommonBll
    {
        public DepartmanBll() : base(KartTuru.Departman) { }
        public DepartmanBll(Control ctrl) : base(ctrl, KartTuru.Departman) { }
    }
}