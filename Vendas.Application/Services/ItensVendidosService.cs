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
    public class ItensVendidosService : IItensVendidosService
    {
        private readonly IItensVendidosRepository _itensVendidosRepository;
        private readonly IMapper _mapper;

        public ItensVendidosService(IItensVendidosRepository itensVendidosRepository, IMapper mapper)
        {
            _mapper = mapper;
            _itensVendidosRepository = itensVendidosRepository;
        }

        public List<ItensVendidosModel> BuscarTodosItensVendidos()
        {
            return _itensVendidosRepository.BuscarTodosItensVendidos();
        }

        public ItensVendidosModel BuscarItensVendidosPorId(int id)
        {
            return _itensVendidosRepository.BuscarItensVendidosPorId(id);
        }

        public bool CadastrarItensVendidos(ItensVendidosInputDTO novoItensVendidos)
        {
            var novoItens = _mapper.Map<ItensVendidosModel>(novoItensVendidos);

            if (!_itensVendidosRepository.CadastrarItensVendidos(novoItens))
                return false;

            return true;
        }

        public string AtualizarItensVendidos(int id, ItensVendidosInputDTO novoItensVendidos)
        {
            var novoItens = _mapper.Map<ItensVendidosModel>(novoItensVendidos);

            return _itensVendidosRepository.AtualizarItensVendidos(id, novoItens);
        }

        public bool RemoverItensVendidos(int id)
        {
            return _itensVendidosRepository.RemoverItensVendidos(id);
        }
    }
}
