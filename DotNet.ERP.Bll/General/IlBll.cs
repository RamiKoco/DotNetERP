using System.Windows.Forms;
using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;

namespace DotNet.ERP.Bll.General
{
  public class IlBll : BaseGenelBll<Il>, IBaseGenelBll,IBaseCommonBll
    {
        public IlBll():base(KartTuru.Il) { }
        public IlBll(Control ctrl):base(ctrl,KartTuru.Il) { }      

    }
}