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
        [Route("buscar-todos-produtos")]
        public IActionResult BuscarProdutos()
        {
            var response = _produtoService.BuscarProdutos();
            if (response.Count() == 0)
                return NoContent();
            return Ok(response);
        }

        [HttpGet("buscar-produto-por-id/{id}")]
        
        public IActionResult BuscarProdutoPorId(int id)
        {
            var produto = _produtoService.BuscarProdutoPorId(id);
            if (produto == null)
                return NoContent();
            return Ok(produto);
        }

        [HttpGet("buscar-produto-por-nome/{nome}")]
        public IActionResult BuscarProdutoPorNome(string nome)
        {
            var response = _produtoService.BuscarProdutoPorNome(nome);
            if (response.Count > 0)
                return Ok(response);
            return NoContent();
        }

        [HttpPost]
        [Route("adicionar-produto")]
        public IActionResult AdicionarProduto([FromBody] ProdutoDTO produto)
        {
            var response = _produtoService.AdicionarProduto(produto);
            if (response)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPut]
        [Route("atualizar-produto")]
        public IActionResult AtualizarProduto([FromBody] ProdutoModel produtoAtualizado)
        {
            var response = _produtoService.AtualizarProduto(produtoAtualizado);
            if (string.IsNullOrEmpty(response))
                return Ok("Produto Atualizado com sucesso");
            return BadRequest(response);
        }

        [HttpDelete]
        [Route("remover-produto/{id}")]
        public IActionResult RemoverProduto(int id)
        { 
            var response = _produtoService.RemoverProduto(id);
            if (!response)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpGet]
        [Route("buscar-produtos-mais-vendidos")]
        public IActionResult ListarProdutosMaisVendidos()
        {
            var response = _produtoService.ProdutoMaisVendido();
            if(response.Any())
                return Ok(response);
            return BadRequest("Não há produtos vendidos");
        }

        [HttpGet]
        [Route("buscar-produtos-disponiveis-por-estoque")]
        public IActionResult BuscarProdutosDisponiveisPorEstoque()
        {
            var response = _produtoService.BuscarProdutosDisponiveisPorEstoque();
            if (response.Any())
                return Ok(response);
            return BadRequest("Não há produtos disponiveis");
        }


    }
}
