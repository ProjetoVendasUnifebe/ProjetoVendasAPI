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
        Task<List<UsuarioModel>> BuscarUsuarios();

        Task<bool> CadastrarUsuario(CadastroUsuarioInputDTO novoUsuario); 
       Task<BuscaUsuarioDTO> BuscarUsuario(string login);
    }
}
