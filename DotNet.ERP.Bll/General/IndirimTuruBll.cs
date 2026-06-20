using System.Windows.Forms;
using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;

namespace DotNet.ERP.Bll.General
{
    public class IndirimTuruBll : BaseGenelBll<IndirimTuru>,IBaseGenelBll,IBaseCommonBll
    {
        public IndirimTuruBll() : base(KartTuru.IndirimTuru) { }
        public IndirimTuruBll(Control ctrl) : base(ctrl, KartTuru.IndirimTuru) { }
    }
}
