using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Domain.DTOs.ViewsDto
{
    public class VendasRealizadasDTO
    {
        public string NomeCliente { get; set; }
        public string Email { get; set; }
        public string DataVenda { get; set; }
        public double ValorDaVenda { get; set; }

    }
}
