using System.ComponentModel;
namespace DotNet.ERP.Common.Enums
{
    public enum MedeniDurum : byte
    {
        [Description("Bekar")]
        Bekar = 1,
        [Description("Evli")]
        Evli = 2,     
    }    
}