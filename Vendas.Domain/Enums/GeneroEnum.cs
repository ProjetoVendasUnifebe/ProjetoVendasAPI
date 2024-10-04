using System.ComponentModel;

namespace Vendas.Domain.Enums
{
    public enum GeneroEnum
    {
        [Description("M")]
        Masculino = 1,

        [Description("F")]
        Feminino = 2,

        [Description("O")]
        Outros = 3
    }
}