using Vendas.Application.Interfaces;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;
using AutoMapper;

namespace Vendas.Application.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly IMapper _mapper;

        public EstoqueService(IEstoqueRepository estoqueRepository, IMapper mapper)
        {
            _estoqueRepository = estoqueRepository;
            _mapper = mapper;
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

        public bool AdicionarEstoque(EstoqueDTO estoque)
        {
            var novoEstoque = _mapper.Map<EstoqueModel>(estoque);
            if (!_estoqueRepository.AdicionarEstoque(novoEstoque))
                return false;

            return true;
        }

        public string AtualizarEstoque(EstoqueModel estoque)
        {
            var novoEstoque = _mapper.Map<EstoqueModel>(estoque);
            return _estoqueRepository.AtualizarEstoque(novoEstoque);
        }

        public bool RemoverEstoque(int id)
        {
            return _estoqueRepository.RemoverEstoque(id);
        }
    }
}