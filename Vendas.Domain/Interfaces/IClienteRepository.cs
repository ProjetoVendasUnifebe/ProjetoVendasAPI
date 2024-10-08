using Vendas.Domain.Entities;

namespace Vendas.Domain.Interfaces
{
    public interface IClienteRepository
    {
        List<ClienteModel> BuscarClientes();
    }
}