using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendas.Domain.DTOs
{
    public class Estoque_ProdutoDTO
    {
        public int IdEstoque { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
    }
}