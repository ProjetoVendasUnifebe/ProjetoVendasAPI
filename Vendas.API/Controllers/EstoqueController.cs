using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Interfaces;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _estoqueService;

        public EstoqueController(IEstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        [HttpGet]
        [Route("buscar-todos-estoques")]
        public IActionResult BuscarEstoques()
        {
            var response = _estoqueService.BuscarEstoques();
            if (response.Count == 0)
                return NoContent();
            return Ok(response);
        }

        [HttpGet("buscar-estoque-por-id/{id}")]
        public IActionResult BuscarEstoquePorId(int id)
        {
            var estoque = _estoqueService.BuscarEstoquePorId(id);
            if (estoque == null)
                return NoContent();
            return Ok(estoque);
        }

        [HttpGet("buscar-estoque-por-nome/{nomeEstoque}")]
        public IActionResult BuscarEstoquePorNome(string nomeEstoque)
        {
            var response = _estoqueService.BuscarEstoquePorNome(nomeEstoque);
            if (response.Count == 0)
                return NoContent();
            return Ok(response);
        }

        [HttpPost]
        [Route("adicionar-estoque")]
        public IActionResult AdicionarEstoque([FromBody] EstoqueDTO estoque)
        {
            var response = _estoqueService.AdicionarEstoque(estoque);
            if (response)
                return Ok(response);
            return BadRequest(response);
            
        }

        [HttpPut]
        [Route("atualizar-estoque")]
        public IActionResult AtualizarEstoque([FromBody] EstoqueModel estoque)
        {
            var response = _estoqueService.AtualizarEstoque(estoque);
            if (string.IsNullOrEmpty(response))
                return Ok("Estoque Atualizado com sucesso");
            return BadRequest(response);
        }

        [HttpDelete]
        [Route("remover-estoque/{id}")]
        public IActionResult RemoverEstoque(int id)
        {
            var response = _estoqueService.RemoverEstoque(id);
            if (!response)  
                return BadRequest(response);
            
            return Ok(response);
        }
    }
}
