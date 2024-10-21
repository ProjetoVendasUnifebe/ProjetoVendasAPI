using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.Application.Interfaces
{
    public interface IEstoqueService
    {
        public List<EstoqueModel> BuscarEstoques();
        public EstoqueModel BuscarEstoquePorId(int id);
        public List<EstoqueModel> BuscarEstoquePorNome(string nomeEstoque);
        public bool AdicionarEstoque(EstoqueDTO estoque);
        public string AtualizarEstoque(EstoqueModel estoque);
        public bool RemoverEstoque(int id);
    }
}