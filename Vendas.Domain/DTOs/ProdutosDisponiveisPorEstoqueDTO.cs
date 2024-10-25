using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Domain.DTOs
{
    public class ProdutosDisponiveisPorEstoqueDTO
    {
        public int IdEstoque_Produto { get; set; }
        public string NomeProduto { get; set; }
        public string Estoque {  get; set; }
        public int Quantidade { get; set; }
    }
}
