using System.Windows.Forms;
using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;

namespace DotNet.ERP.Bll.General
{
    public class FiltreBll : BaseGenelBll<Filtre>, IBaseCommonBll
    {
        public FiltreBll():base(KartTuru.Filtre) { }
        public FiltreBll(Control ctrl) : base(ctrl,KartTuru.Filtre) { }    
    }
}