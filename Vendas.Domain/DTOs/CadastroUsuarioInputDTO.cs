using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Domain.DTOs
{
    public class CadastroUsuarioInputDTO
    {
        public string NomeUsuario {  get; set; }
        public string Senha {  get; set; }
        public int EhAdm { get; set; }
        public string Login { get; set; }
    }
}
