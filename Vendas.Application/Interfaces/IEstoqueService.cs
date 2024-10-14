using Vendas.Domain.Entities;

namespace Vendas.Application.Interfaces
{
    public interface IEstoqueService
    {
        public List<EstoqueModel> BuscarEstoques();
        public EstoqueModel BuscarEstoquePorId(int id);
        public List<EstoqueModel> BuscarEstoquePorNome(string nomeEstoque);
        public bool AdicionarEstoque(EstoqueModel estoque);
        public bool AtualizarEstoque(EstoqueModel estoque);
        public bool RemoverEstoque(int id);
    }
}