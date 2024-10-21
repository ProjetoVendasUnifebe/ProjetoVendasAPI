using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendas.Domain.DTOs
{
    public class EstoqueProdutoDTO
    {
        public int IdEstoque { get; set; }
        public int IdProduto { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int Quantidade { get; set; }
    }
}