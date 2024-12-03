using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Domain.DTOs.ViewsDto
{
    public class FaturamentoDTO
    {
        public int Mes { get; set; }
        public int Ano { get; set; }
        public double Faturamento { get; set; }
    }
}
