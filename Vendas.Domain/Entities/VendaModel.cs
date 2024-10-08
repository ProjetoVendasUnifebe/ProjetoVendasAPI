using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Domain.Enums;

namespace Vendas.Domain.Entities
{
    public class VendaModel
    {
        public int IdVenda { get; set; }
        public int IdUsuario { get; set; }
        public int IdCliente { get; set; }
        public decimal valor { get; set; }
        public DateTime data_venda { get; set; }
        public FormaPagamentoEnum forma_pagamento { get; set; }
    }
}
