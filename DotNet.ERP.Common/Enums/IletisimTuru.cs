using System.ComponentModel;

namespace DotNet.ERP.Common.Enums
{
    public enum IletisimTuru : byte
    {
        [Description("Telefon")]
        Telefon = 1,
        [Description("E-Posta")]
        EPosta = 2,
        [Description("Web")]
        Web = 3,
        [Description("Sosyal Medya")]
        SosyalMedya = 4,
        [Description("Fax")]
        Fax = 5
    }
}
