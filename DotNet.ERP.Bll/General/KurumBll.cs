using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using System.Windows.Forms;

namespace DotNet.ERP.Bll.General
{
    public class KurumBll : BaseGenelYonetimBll<Kurum>, IBaseGenelBll, IBaseCommonBll
    {
        public KurumBll() : base(KartTuru.Kurum) { }
        public KurumBll(Control ctrl) : base(ctrl, KartTuru.Kurum) { }
    }
}