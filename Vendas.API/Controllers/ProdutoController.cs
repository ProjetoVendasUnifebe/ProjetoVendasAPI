using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Interfaces;
using Vendas.Application.Services;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController( IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        [Route("buscar-produtos")]
        public IActionResult BuscarProdutos()
        {
            var response = _produtoService.BuscarProdutos();
            if (response.Count() == 0)
                return BadRequest(new ErroDTO("Lista Vazia", "Aparentemente a lista de produtos esta vazia"));
            return Ok(response);
        }

        [HttpGet("produto-por-id/{id}")]
        
        public IActionResult BuscarProdutoPorId(int id)
        {
            var produto = _produtoService.BuscarProdutoPorId(id);
            if (produto == null)
                return BadRequest(new ErroDTO("Produto não encontrado", "O produto não foi encontrado"));
            return Ok(produto);
        }

        [HttpGet("produto-por-nome/{nome}")]
        public IActionResult BuscarProdutoPorNome(string nome)
        {
            var response = _produtoService.BuscarProdutoPorNome(nome);
            if (response == null)
                return BadRequest(new ErroDTO("Produto não encontrado", "O produto não foi encontrado"));
            return Ok(response);
        }

        [HttpPost]
        [Route("adicionar-produto")]
        public IActionResult AdicionarProduto(ProdutoModel produto)
        {
            var response = _produtoService.AdicionarProduto(produto);
            if (response == null)
                return BadRequest(new ErroDTO("Erro ao adicionar produto", "Ocorreu um erro ao adicionar o produto"));
            return Ok("Produto Adicionado");
        }

        [HttpPut]
        [Route("atualizar-produto")]
        public IActionResult AtualizarProduto(ProdutoModel produto)
        {
            var response = _produtoService.AtualizarProduto(produto);
            if (response == null)
                return BadRequest(new ErroDTO("Erro ao atualizar produto", "Ocorreu um erro ao atualizar o produto"));
            return Ok("Produto Atualizado");
        }

        [HttpDelete("remover-produto")]
        public IActionResult RemoverProduto(int id)
        { 
            var response = _produtoService.RemoverProduto(id);
            if (response == false)
                return BadRequest(new ErroDTO("Erro ao remover produto", "Ocorreu um erro ao remover o produto"));
            return Ok("Produto Removido");
        }

    }
}
