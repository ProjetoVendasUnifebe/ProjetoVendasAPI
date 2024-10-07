using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;
using AutoMapper;

namespace Vendas.Application.Mappers
{
    public class DomainToDTO : Profile
    {
        public DomainToDTO()
        {
            CreateMap<UsuarioModel, BuscaUsuarioDTO>();
        }
    }
}
