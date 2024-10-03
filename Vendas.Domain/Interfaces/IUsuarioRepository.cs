using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Domain.Entities;

namespace Vendas.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        List<UsuarioModel> BuscarUsuarios();
    }
}
