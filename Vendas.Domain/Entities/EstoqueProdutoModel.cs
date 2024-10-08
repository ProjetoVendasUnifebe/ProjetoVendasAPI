using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendas.Domain.Entities
{
    public class EstoqueProdutoModel
    {
        public int IdEstoque_Produto { get; set; }
        public int IdEstoque { get; set; }
        public int IdProduto { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int Quantidade { get; set; }
    }
}