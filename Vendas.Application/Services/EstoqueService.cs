using Vendas.Application.Interfaces;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;

namespace Vendas.Application.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IEstoqueRepository _estoqueRepository;
        
        public EstoqueService(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        public List<EstoqueModel> BuscarEstoques()
        {
            return _estoqueRepository.BuscarEstoques();
        }

        public EstoqueModel BuscarEstoquePorId(int id)
        {
            return _estoqueRepository.BuscarEstoquePorId(id);
        }

        public List<EstoqueModel> BuscarEstoquePorNome(string nomeEstoque)
        {
            return _estoqueRepository.BuscarEstoquePorNome(nomeEstoque);
        }

        public bool AdicionarEstoque(EstoqueModel estoque)
        {
            return _estoqueRepository.AdicionarEstoque(estoque);
        }

        public bool AtualizarEstoque(EstoqueModel estoque)
        {
            return _estoqueRepository.AtualizarEstoque(estoque);
        }

        public bool RemoverEstoque(int id)
        {
            return _estoqueRepository.RemoverEstoque(id);
        }
    }
}