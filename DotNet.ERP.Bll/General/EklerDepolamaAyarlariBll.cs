using DotNet.ERP.Bll.Base;
using DotNet.ERP.Bll.Interfaces;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using System.Windows.Forms;

namespace DotNet.ERP.Bll.General
{
    public class EklerDepolamaAyarlariBll :BaseGenelBll<EklerDepolamaAyarlari>, IBaseCommonBll
    {
        public EklerDepolamaAyarlariBll() : base(KartTuru.EklerDepolamaAyarlari) { }

        public EklerDepolamaAyarlariBll(Control ctrl) : base(ctrl, KartTuru.EklerDepolamaAyarlari) { }
        public string GetKokDizin()
        {
            return Single(x => x.Kod == "EKLER_DEPOLAMA") is EklerDepolamaAyarlari ayar
                ? ayar.KokDizin
                : null;
        }
    }
}