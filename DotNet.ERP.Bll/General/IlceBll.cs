using System.Windows.Forms;
using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
namespace DotNet.ERP.Bll.General
{
    public class IlceBll : BaseGenelBll<Ilce>,IBaseCommonBll
    {
        public IlceBll():base(KartTuru.Ilce) { }

        public IlceBll(Control ctrl) : base(ctrl,KartTuru.Ilce) { }    
    }
}