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
    public class DTOToDomain : Profile
    {
        public DTOToDomain()
        {
            CreateMap<UsuarioDTO, UsuarioModel>();
            CreateMap<VendaInputDTO, VendaModel>();
            CreateMap<VendaAtualizaInputDTO, VendaModel>();
            CreateMap<ItensVendidosInputDTO, ItensVendidosModel>();
            CreateMap<ProdutoDTO, ProdutoModel>();
        }
    }
}
