﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Domain.DTOs
{
    public class ProdutoMaisVendidoDTO
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public int TotalVendido { get; set; }
    }
}