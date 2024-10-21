using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.Application.Interfaces
{
    public interface IClienteService
    {
        List<ClienteModel> BuscarClientes();
        ClienteModel BuscarClientePorId(int id);
        List<ClienteModel> BuscarClientePorNome(string nomeCliente);
        bool AdicionarCliente(ClienteInputDTO cliente);
        string AtualizarCliente(ClienteModel cliente);
        bool RemoverCliente(int id);
    }
}