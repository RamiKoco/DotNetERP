using System.Windows.Forms;
using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;

namespace DotNet.ERP.Bll.General
{
    public class KontenjanBll:BaseGenelBll<Kontenjan>,IBaseGenelBll,IBaseCommonBll
    {
        public KontenjanBll() : base(KartTuru.Kontenjan) { }
        public KontenjanBll(Control ctrl) : base(ctrl, KartTuru.Kontenjan) { }
    }
}