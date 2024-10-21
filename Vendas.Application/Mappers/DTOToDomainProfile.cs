using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.Application.Mappers
{
    public class DTOToDomainProfile : Profile
    {
        public DTOToDomainProfile() 
        {
            CreateMap< UsuarioInputDTO, UsuarioModel>();
            CreateMap<ClienteInputDTO, ClienteModel>();
        }
    }
}
