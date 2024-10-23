using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Domain.DTOs
{
    public class EstoqueProdutoAtualizaDTO
    {
        public int IdEstoque_Produto { get; set; }
        public int IdEstoque { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }

    }
}
