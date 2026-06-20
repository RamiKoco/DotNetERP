using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using System.Windows.Forms;
using DotNet.ERP.Model.Entities;

namespace DotNet.ERP.Bll.General
{
    public class SinifGrupBll : BaseGenelBll<SinifGrup>, IBaseGenelBll, IBaseCommonBll
    {
        public SinifGrupBll() : base(KartTuru.SinifGrup) { }

        public SinifGrupBll(Control ctrl) : base(ctrl, KartTuru.SinifGrup) { }
    }
}
