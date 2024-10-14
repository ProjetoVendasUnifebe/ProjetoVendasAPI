using Vendas.Application.Interfaces;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;

namespace Vendas.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
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

        public bool AdicionarCliente(ClienteModel cliente)
        {
            return _clienteRepository.AdicionarCliente(cliente);
        }

        public bool AtualizarCliente(ClienteModel cliente)
        {
            return _clienteRepository.AtualizarCliente(cliente);
        }

        public bool RemoverCliente(int id)
        {
            return _clienteRepository.RemoverCliente(id);
        }
    }
}