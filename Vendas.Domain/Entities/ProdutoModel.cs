using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Domain.Enums;

namespace Vendas.Domain.Entities
{
    public class ProdutoModel
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
    }
}
