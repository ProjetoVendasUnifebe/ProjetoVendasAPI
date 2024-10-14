using Vendas.Domain.Entities;

namespace Vendas.Domain.Interfaces
{
    public interface IEstoqueRepository
    {
        List<EstoqueModel> BuscarEstoques();
        EstoqueModel BuscarEstoquePorId(int id);
        List<EstoqueModel> BuscarEstoquePorNome(string nomeEstoque);
        bool AdicionarEstoque(EstoqueModel estoque);
        bool AtualizarEstoque(EstoqueModel estoque);
        bool RemoverEstoque(int id);

    }
}