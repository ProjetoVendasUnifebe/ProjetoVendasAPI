using Vendas.Application.Interfaces;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;

namespace Vendas.Application.Services
{
    public class Estoque_ProdutoService : IEstoque_ProdutoService
    {
        private readonly IEstoque_ProdutoRepository _estoqueProdutoRepository;

        public Estoque_ProdutoService(IEstoque_ProdutoRepository estoqueProdutoRepository)
        {
            _estoqueProdutoRepository = estoqueProdutoRepository;
        }

        public List<EstoqueProdutoModel> BuscarEstoqueProduto()
        {
            return _estoqueProdutoRepository.BuscarEstoqueProduto();
        }

        public List<EstoqueProdutoModel> BuscarEstoqueProdutoPorIdEstoque(int idEstoque)
        {
            return _estoqueProdutoRepository.BuscarEstoqueProdutoPorIdEstoque(idEstoque);
        }

        public List<EstoqueProdutoModel> BuscarEstoqueProdutoPorIdProduto(int idProduto)
        {
            return _estoqueProdutoRepository.BuscarEstoqueProdutoPorIdProduto(idProduto);
        }

        public List<EstoqueProdutoModel> BuscarEstoqueProdutoPorQuantidade(int quantidade)
        {
            return _estoqueProdutoRepository.BuscarEstoqueProdutoPorQuantidade(quantidade);
        }
        public bool AdicionarEstoqueProduto(EstoqueProdutoModel estoqueProduto)
        {
            return _estoqueProdutoRepository.AdicionarEstoqueProduto(estoqueProduto);
        }

        public string AtualizarEstoqueProduto(int id, Estoque_ProdutoDTO estoqueProduto)
        {
            return _estoqueProdutoRepository.AtualizarEstoqueProduto(id, estoqueProduto);
        }

        public bool RemoverEstoqueProduto(int idEstoqueProduto)
        {
            return _estoqueProdutoRepository.RemoverEstoqueProduto(idEstoqueProduto);
        }
    }
}