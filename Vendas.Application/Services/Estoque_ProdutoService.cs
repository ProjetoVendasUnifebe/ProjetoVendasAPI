using Vendas.Application.Interfaces;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;
using AutoMapper;

namespace Vendas.Application.Services
{
    public class Estoque_ProdutoService : IEstoque_ProdutoService
    {
        private readonly IEstoque_ProdutoRepository _estoqueProdutoRepository;
        private readonly IMapper _mapper;
        public Estoque_ProdutoService(IEstoque_ProdutoRepository estoqueProdutoRepository, IMapper mapper)
        {
            _estoqueProdutoRepository = estoqueProdutoRepository;
            _mapper = mapper;
        }
        public List<EstoqueProdutoModel> BuscarEstoqueProduto()
        {
            return _estoqueProdutoRepository.BuscarEstoqueProduto();
        }

        public EstoqueProdutoModel BuscarEstoqueProdutoPorId(int id)
        {
            return _estoqueProdutoRepository.BuscarEstoqueProdutoPorId(id);
        }

        public List<EstoqueProdutoModel> BuscarEstoqueProdutoPorIdEstoque(int idEstoque)
        {
            return _estoqueProdutoRepository.BuscarEstoqueProdutoPorIdEstoque(idEstoque);
        }

        public List<EstoqueProdutoModel> BuscarEstoqueProdutoPorIdProduto(int idProduto)
        {
            return _estoqueProdutoRepository.BuscarEstoqueProdutoPorIdProduto(idProduto);
        }
        public bool AdicionarEstoqueProduto(EstoqueProdutoDTO estoqueProduto)
        {
            var novoEstoqueProduto = _mapper.Map<EstoqueProdutoModel>(estoqueProduto);

            if(!_estoqueProdutoRepository.AdicionarEstoqueProduto(novoEstoqueProduto))
                return false;
            return true;
        }

        public string AtualizarEstoqueProduto(EstoqueProdutoAtualizaDTO estoqueProduto)
        {
            var novoEstoqueProduto = _mapper.Map<EstoqueProdutoModel>(estoqueProduto);
            return _estoqueProdutoRepository.AtualizarEstoqueProduto(novoEstoqueProduto);
        }

        public bool RemoverEstoqueProduto(int idEstoqueProduto)
        {
            return _estoqueProdutoRepository.RemoverEstoqueProduto(idEstoqueProduto);
        }
    }
}