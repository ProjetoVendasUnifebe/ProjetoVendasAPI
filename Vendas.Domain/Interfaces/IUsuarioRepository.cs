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
        Task<List<UsuarioModel>> BuscarUsuarios();
        Task<bool> CadastrarUsuario(UsuarioModel novoUsuario);
        Task<UsuarioModel> BuscarUsuario(string login);

    }
}
