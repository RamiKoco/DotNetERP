using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities.KisiEntity;
using System.Windows.Forms;

namespace DotNet.ERP.Bll.General.KisiBll
{
    public class KisiGrubuBll : BaseGenelBll<KisiGrubu>, IBaseGenelBll, IBaseCommonBll
    {
        public KisiGrubuBll() : base(KartTuru.KisiGrubu) { }
        public KisiGrubuBll(Control ctrl) : base(ctrl, KartTuru.KisiGrubu) { }
    }
}