using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.Domain.Interfaces.Repositories
{
    public interface IEstoqueRepository
    {
        List<EstoqueModel> BuscarEstoques();
        EstoqueModel BuscarEstoquePorId(int id);
        List<EstoqueModel> BuscarEstoquePorNome(string nomeEstoque);
        bool AdicionarEstoque(EstoqueModel estoque);
        string AtualizarEstoque(EstoqueModel estoque);
        bool RemoverEstoque(int id);

    }
}