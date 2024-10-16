using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Application.Interfaces;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;
using System.Security.Cryptography;
using AutoMapper;
using System.Net.Mail;


namespace Vendas.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper) 
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public List<UsuarioModel> BuscarUsuarios()
        {
            var response =  _usuarioRepository.BuscarUsuarios();
            if (response == null)
                return new List<UsuarioModel>();

            return response;
        }

        public BuscaUsuarioDTO BuscarUsuarioPorLogin(string login)
        {
            var response = _usuarioRepository.BuscarUsuarioPorLogin(login);

            if (response == null) 
                return new BuscaUsuarioDTO();

            var usuarioDTO = _mapper.Map<BuscaUsuarioDTO>(response);

            return usuarioDTO;
        }

        public bool CadastrarUsuario(UsuarioInputDTO cadastroUsuarioInputDTO)
        {

            cadastroUsuarioInputDTO.Senha = BCrypt.Net.BCrypt.HashPassword(cadastroUsuarioInputDTO.Senha);

            var novoUsuario = _mapper.Map<UsuarioModel>(cadastroUsuarioInputDTO);

            if (! _usuarioRepository.CadastrarUsuario(novoUsuario))
                return false;

            return true;

        }

        public bool RealizarLogin(string login, string senha)
        {
            var usuario = _usuarioRepository.BuscarUsuarioPorLogin(login);
            if (usuario == null)
                return false;

            return BCrypt.Net.BCrypt.Verify(senha, usuario.Senha);
        }

        public BuscaUsuarioDTO BuscarUsuarioPorId(int id)
        {
            var response = _usuarioRepository.BuscarUsuarioPorId(id);

            if (response == null)
                return new BuscaUsuarioDTO();

            var usuarioDTO = _mapper.Map<BuscaUsuarioDTO>(response);

            return usuarioDTO;
        }

        public List<BuscaUsuarioDTO> BuscarUsuarioPorNome(string nome)
        {
            var response = _usuarioRepository.BuscarUsuarioPorNome(nome);
            if (response == null)
                return new List<BuscaUsuarioDTO>();

            var usuarioDTO = _mapper.Map<List<BuscaUsuarioDTO>>(response);

            return usuarioDTO;
        }

        public string AtualizarUsuario(int id, UsuarioDTO usuarioAtualizado)
        {
            var novoUsuario = _mapper.Map<UsuarioModel>(usuarioAtualizado);
            return _usuarioRepository.AtualizarUsuario(id, novoUsuario);
        }

        public string AtualizarSenhaUsuario(string login, string senha)
        {
            senha = BCrypt.Net.BCrypt.HashPassword(senha);
            return _usuarioRepository.AtuaizarSenhaUsuario(login, senha);
        }

        public bool RemoverUsuario(int id)
        {
            return _usuarioRepository.RemoverUsuario(id);
        }
    }
}
