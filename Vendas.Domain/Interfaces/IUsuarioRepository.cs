using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        List<UsuarioModel> BuscarUsuarios();
        bool CadastrarUsuario(UsuarioModel novoUsuario);
        UsuarioModel BuscarUsuarioPorLogin(string login);
        UsuarioModel BuscarUsuarioPorId(int id);
        List<UsuarioModel> BuscarUsuarioPorNome(string nome);
        string AtualizarUsuario(UsuarioModel usuarioAtualizado);
        string AtuaizarSenhaUsuario(string login, string senha);
        bool RemoverUsuario(int id);

    }
}
