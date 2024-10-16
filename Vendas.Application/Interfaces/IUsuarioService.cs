using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.Application.Interfaces
{
    public interface IUsuarioService
    {
        List<UsuarioModel> BuscarUsuarios();
       bool CadastrarUsuario(UsuarioInputDTO novoUsuario); 
       BuscaUsuarioDTO BuscarUsuarioPorLogin(string login);
       bool RealizarLogin(string login, string senha);
       BuscaUsuarioDTO BuscarUsuarioPorId(int id);
       List<BuscaUsuarioDTO> BuscarUsuarioPorNome(string nome);
        string AtualizarUsuario(int id, UsuarioDTO usuarioAtualizado);
        string AtualizarSenhaUsuario(string login, string senha);
        bool RemoverUsuario(int id);
    }
}
