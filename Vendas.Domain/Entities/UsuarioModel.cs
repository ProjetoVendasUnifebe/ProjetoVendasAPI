﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Domain.Entities
{
    public class UsuarioModel
    {
        public int Id { get;  set; }
        public string Nome { get;  set; }
        public string CPF { get;  set; }
        public string Cargo { get;  set; }
    }
}
