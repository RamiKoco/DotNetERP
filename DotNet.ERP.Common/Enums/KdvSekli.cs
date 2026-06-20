using System.ComponentModel;

namespace DotNet.ERP.Common.Enums
{
    public enum KdvSekli : byte
    {
        [Description("Dahil")]
        Dahil = 1,
        
        [Description("Hariç")]
        Haric = 2,
    }
}
