using System.ComponentModel;

namespace DotNet.ERP.Common.Enums
{
    public enum EposKartTuru:byte
    {
        [Description("Visa")]
        Visa=1,
        [Description("Mastercard")]
        Master =2,
        [Description("American Express")]
        AmericanExpress =3
    }
}