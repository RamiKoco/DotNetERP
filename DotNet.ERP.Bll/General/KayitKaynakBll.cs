using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using System.Windows.Forms;

namespace DotNet.ERP.Bll.General
{
    public class KayitKaynakBll : BaseGenelBll<Model.Entities.KayitKaynak>, IBaseGenelBll, IBaseCommonBll
    {
        public KayitKaynakBll() : base(KartTuru.KayitKaynak) { }
        public KayitKaynakBll(Control ctrl) : base(ctrl, KartTuru.KayitKaynak) { }
    }
}
