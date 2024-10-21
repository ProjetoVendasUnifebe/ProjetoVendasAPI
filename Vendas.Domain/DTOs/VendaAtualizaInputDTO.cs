using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Domain.DTOs
{
    public class VendaAtualizaInputDTO
    {
        public int IdVenda { get; set; }
        public int IdUsuario { get; set; }
        public int IdCliente { get; set; }
        public decimal valor { get; set; }
        public DateTime? data_venda { get; set; }
        public string forma_pagamento { get; set; }
    }
}
