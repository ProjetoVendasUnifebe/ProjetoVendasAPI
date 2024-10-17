using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Domain.DTOs
{
    public class ItensVendidosInputDTO
    {
        public int IdVenda { get; set; }
        public int IdProduto { get; set; }
        public int QtdVendida { get; set; }
    }
}
