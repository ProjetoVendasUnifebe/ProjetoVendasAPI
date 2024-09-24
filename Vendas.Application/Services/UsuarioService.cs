using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Application.Interfaces;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;

namespace Vendas.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService (IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;

        }

        public List<UsuarioModel> ListarTodosUsuarios()
        {
            var response = _usuarioRepository.BuscarUsuarios();
            if (response == null)
                return new List<UsuarioModel>();

            return response;
        }

        public UsuarioDTO BuscarNomeUsuario(int id) 
        { 
            var response = _usuarioRepository.BuscarUsuario(id);
            if (response == null)
                return new UsuarioDTO();

            return _mapper.Map<UsuarioDTO>(response);  
        }
    }
}
