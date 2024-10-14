using Vendas.Domain.Entities;

namespace Vendas.Domain.Interfaces
{
    public interface IClienteRepository
    {
        List<ClienteModel> BuscarClientes();
        ClienteModel BuscarClientePorId(int id);
        List<ClienteModel> BuscarClientePorNome(string nomeCliente);
        bool AdicionarCliente(ClienteModel cliente);
        bool AtualizarCliente(ClienteModel cliente);
        bool RemoverCliente(int id);
    }
}