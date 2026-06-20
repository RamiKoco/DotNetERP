using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using System.Windows.Forms;

namespace DotNet.ERP.Bll.General
{
    public class UlkeBll : BaseGenelBll<Model.Entities.Ulke>, IBaseGenelBll, IBaseCommonBll
    {
        public UlkeBll() : base(KartTuru.Ulke) { }
        public UlkeBll(Control ctrl) : base(ctrl, KartTuru.Ulke) { }
    }
}
