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
    public class VendaService : IVendaService
    {
        private readonly IMapper _mapper;
        private readonly IVendaRepository _IVendaRepository;
        public VendaService(IVendaRepository iVendaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _IVendaRepository = iVendaRepository;
        }
        public List<VendaModel> BuscarTodos()
        {
            return _IVendaRepository.BuscarVendas();
        }

        public List<VendaModel> BuscarVendasPorData(DateTime? dataInicio, DateTime? dataFim)
        {
            return _IVendaRepository.BuscarVendasPorData(dataInicio, dataFim);
        }

        public bool CadastrarVenda(VendaInputDTO novaVenda)
        {

            novaVenda.data_venda = novaVenda.data_venda.ToUniversalTime();
            var novoUsuario = _mapper.Map<VendaModel>(novaVenda);

            if (!_IVendaRepository.CadastrarVenda(novoUsuario))
                return false;

            return true;
        }

        public string AtualizarVenda(int id, VendaAtualizaInputDTO novaVenda)
        {
            var venda = _mapper.Map<VendaModel>(novaVenda);
            return _IVendaRepository.AtualizarVenda(id, venda);
        }

        public bool RemoverVenda(int id)
        {
            return _IVendaRepository.RemoverVenda(id);
        }

        public VendaModel BuscarVendaPorId(int id)
        {
            var response = _IVendaRepository.BuscarVendaPorId(id);

            if (response == null)
                return new VendaModel();

            return response;
        }
    }
}
