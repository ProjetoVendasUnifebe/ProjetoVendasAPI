using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendas.Domain.Enums;

namespace Vendas.Domain.Entities
{
    public class ClienteModel
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public GeneroEnum Sexo { get; set; }
        public int IdEndereco { get; set; }
    }
}