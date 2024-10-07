using Vendas.Application.Interfaces;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;

namespace Vendas.Application.Services
{
   public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
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
            return _produtoRepository.BuscarProdutoPorId(id);
        }

        public ProdutoModel BuscarProdutoPorNome(string nome)
        {
            return _produtoRepository.BuscarProdutoPorNome(nome);
        }

        public void AdicionarProduto(ProdutoModel produto)
        {
            _produtoRepository.AdicionarProduto(produto);
        }

        public void AtualizarProduto(ProdutoModel produto)
        {
            _produtoRepository.AtualizarProduto(produto);
        }

        public void RemoverProduto(int id)
        {
            _produtoRepository.RemoverProduto(id);
        }
    }
}