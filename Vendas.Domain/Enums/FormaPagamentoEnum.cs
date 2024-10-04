using System.ComponentModel;

namespace Vendas.Domain.Enums
{
        public enum FormaPagamentoEnum
        {
            [Description("Dinheiro")]
            Dinheiro = 1,
            [Description("Cartao de Crédito")]
            CartaoCredito = 2,
            [Description("Cartao de Débito")]
            CartaodeDebito = 3,
            [Description("Pix")]
            Pix = 4,
            [Description("Boleto")]
            Boleto = 5
        }
}