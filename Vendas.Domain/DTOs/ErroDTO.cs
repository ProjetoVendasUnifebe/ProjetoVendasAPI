using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Domain.DTOs
{
    public class ErroDTO
    {
        public string TipoErro { get; set; }
        public string Descricao { get; set; }

        public ErroDTO(string tipoErro, string descricao)
        {
            TipoErro = tipoErro;
            Descricao = descricao;
        }
    }
}
