using System.Windows.Forms;
using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;

namespace DotNet.ERP.Bll.General
{
    public class ServisBll:BaseGenelBll<Servis>,IBaseCommonBll
    {
        public ServisBll() : base(KartTuru.Servis) { }
        public ServisBll(Control ctrl) : base(ctrl, KartTuru.Servis) { }
    }
}
