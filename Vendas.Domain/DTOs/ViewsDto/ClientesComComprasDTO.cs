using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Domain.DTOs.ViewsDto
{
    public class ClientesComComprasDTO
    {
        public int idCliente { get; set; }
        public string nomeCliente { get; set; }
        public int numeroDeCompras { get; set; }
        public double totalDasCompras { get; set; }
    }
}
