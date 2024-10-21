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
                return NoContent();
            return Ok(response);
        }

        [HttpGet("produto-por-id/{id}")]
        
        public IActionResult BuscarProdutoPorId(int id)
        {
            var produto = _produtoService.BuscarProdutoPorId(id);
            if (produto == null)
                return NoContent();
            return Ok(produto);
        }

        [HttpGet("produto-por-nome/{nome}")]
        public IActionResult BuscarProdutoPorNome(string nome)
        {
            var response = _produtoService.BuscarProdutoPorNome(nome);
            if (response == null)
                return NoContent();
            return Ok(response);
        }

        [HttpPost]
        [Route("adicionar-produto")]
        public IActionResult AdicionarProduto([FromBody] ProdutoDTO produto)
        {
            if (_produtoService.AdicionarProduto(produto))
                return Ok("Produto Adicionado com sucesso");
            return BadRequest(new ErroDTO("Erro ao adicionar produto", "Ocorreu um erro ao adicionar o produto"));
            
        }

        [HttpPut]
        [Route("atualizar-produto")]
        public IActionResult AtualizarProduto([FromBody] ProdutoModel produtoAtualizado)
        {
            var response = _produtoService.AtualizarProduto(produtoAtualizado);
            if (string.IsNullOrEmpty(response))
                return Ok("Produto Atualizado com sucesso");
            return BadRequest(new ErroDTO("Erro ao atualizar produto", "Ocorreu um erro ao atualizar o produto"));
            
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
