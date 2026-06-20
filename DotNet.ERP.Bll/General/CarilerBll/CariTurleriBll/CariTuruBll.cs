using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities.CariEntity.CariTurleri;
using System.Windows.Forms;

namespace DotNet.ERP.Bll.General.CarilerBll.CariTurleriBll
{
    public class CariTuruBll : BaseGenelBll<CariTuru>, IBaseGenelBll, IBaseCommonBll
    {
        public CariTuruBll() : base(KartTuru.CariTuru) { }
        public CariTuruBll(Control ctrl) : base(ctrl, KartTuru.CariTuru) { }
    }
}