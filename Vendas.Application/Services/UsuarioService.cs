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
            var response = _usuarioRepository.BuscarUsuarios();
            if (response == null)
                return new List<UsuarioModel>();

            return response;
        }

        public bool CadastrarUsuario(CadastroUsuarioInputDTO cadastroUsuarioInputDTO)
        {

            cadastroUsuarioInputDTO.Senha = BCrypt.Net.BCrypt.HashPassword(cadastroUsuarioInputDTO.Senha);
           // BCrypt.Net.BCrypt.Verify(senha, senha)

            var novoUsuario = _mapper.Map<UsuarioModel>(cadastroUsuarioInputDTO);

            if (!_usuarioRepository.CadastrarUsuario(novoUsuario))
                return false;

            return true;

        }



    }
}
