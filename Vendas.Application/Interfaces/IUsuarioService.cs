using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Application.Services;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.Application.Interfaces
{
    public interface IUsuarioService
    {
         List<UsuarioModel> ListarTodosUsuarios();
        UsuarioDTO BuscarNomeUsuario(int id);


    }
}
