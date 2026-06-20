using System.ComponentModel;
namespace DotNet.ERP.Common.Enums
{
    public enum Cinsiyet : byte
    {
        [Description("Erkek")]
        Erkek = 1,
        [Description("Kadın")]
        Kadin = 2,
    }
}