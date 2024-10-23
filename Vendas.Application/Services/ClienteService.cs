using AutoMapper;
using Vendas.Application.Interfaces;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces.Repositories;

namespace Vendas.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        public List<ClienteModel> BuscarClientes()
        {
            return _clienteRepository.BuscarClientes();
        }

        public ClienteModel BuscarClientePorId(int id)
        {
            return _clienteRepository.BuscarClientePorId(id);
        }

        public List<ClienteModel> BuscarClientePorNome(string nomeCliente)
        {
            return _clienteRepository.BuscarClientePorNome(nomeCliente);
        }

        public bool AdicionarCliente(ClienteInputDTO cliente)
        {
            var novoCliente = _mapper.Map<ClienteModel>(cliente);
            return _clienteRepository.AdicionarCliente(novoCliente);
        }

        public string AtualizarCliente(ClienteModel cliente)
        {
            return _clienteRepository.AtualizarCliente(cliente);
        }

        public bool RemoverCliente(int id)
        {
            return _clienteRepository.RemoverCliente(id);
        }
    }
}