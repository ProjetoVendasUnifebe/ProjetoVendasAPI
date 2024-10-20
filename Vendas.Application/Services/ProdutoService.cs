using Vendas.Application.Interfaces;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;
using Vendas.Application.Mappers;
using AutoMapper;

namespace Vendas.Application.Services
{
    public class ProdutoService : IProdutoService

    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }
        public List<ProdutoModel> BuscarProdutos()
        {
            var response = _produtoRepository.BuscarProdutos();
            if (response == null)
                return new List<ProdutoModel>();

            return response;
        }

        public ProdutoModel BuscarProdutoPorId(int id)
        {
            var produto = _produtoRepository.BuscarProdutoPorId(id);
            return produto;
        }

        public List<ProdutoModel> BuscarProdutoPorNome(string nome)
        {
            var produto = _produtoRepository.BuscarProdutoPorNome(nome);
            return produto;
        }

        public bool AdicionarProduto(ProdutoDTO produto)
        {
            var novoProduto = _mapper.Map<ProdutoModel>(produto);
            if (!_produtoRepository.AdicionarProduto(novoProduto))
                return false;

            return true;
        }

        public string AtualizarProduto(ProdutoModel produtoAtualizado)
        {
            var novoProduto = _mapper.Map<ProdutoModel>(produtoAtualizado);
            return _produtoRepository.AtualizarProduto(novoProduto);
        }


        public bool RemoverProduto(int id)
        {
            return _produtoRepository.RemoverProduto(id);
        }
    }
}