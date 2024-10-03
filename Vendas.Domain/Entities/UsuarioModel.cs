using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Domain.Entities
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }

        public string Senha { get; set; }
    }
}
