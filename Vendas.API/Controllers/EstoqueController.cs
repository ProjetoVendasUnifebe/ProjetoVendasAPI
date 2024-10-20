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
        [Route("buscar-estoques")]
        public IActionResult BuscarEstoques()
        {
            var response = _estoqueService.BuscarEstoques();
            if (response.Count == 0)
                return NoContent();
            return Ok(response);
        }

        [HttpGet("estoque-por-id/{id}")]
        public IActionResult BuscarEstoquePorId(int id)
        {
            var estoque = _estoqueService.BuscarEstoquePorId(id);
            if (estoque == null)
                return NoContent();
            return Ok(estoque);
        }

        [HttpGet("estoque-por-nome/{nomeEstoque}")]
        public IActionResult BuscarEstoquePorNome(string nomeEstoque)
        {
            var response = _estoqueService.BuscarEstoquePorNome(nomeEstoque);
            if (response == null)
                return NoContent();
            return Ok(response);
        }

        [HttpPost]
        [Route("adicionar-estoque")]
        public IActionResult AdicionarEstoque([FromBody] EstoqueDTO estoque)
        {
           
            if(_estoqueService.AdicionarEstoque(estoque))
                return Ok("Estoque Adicionado com sucesso");
            return BadRequest(new ErroDTO("Erro ao adicionar estoque", "Ocorreu um erro ao adicionar o estoque"));
            
        }

        [HttpPut]
        [Route("atualizar-estoque")]
        public IActionResult AtualizarEstoque([FromBody] EstoqueModel estoque)
        {
            var response = _estoqueService.AtualizarEstoque(estoque);
            if (string.IsNullOrEmpty(response))
                return Ok("Estoque Atualizado com sucesso");
            return BadRequest(new ErroDTO("Erro ao atualizar estoque", "Ocorreu um erro ao atualizar o estoque"));
            
        }

        [HttpDelete]
        [Route("remover-estoque")]
        public IActionResult RemoverEstoque(int id)
        {
            var response = _estoqueService.RemoverEstoque(id);
            if (response == false)  
                return BadRequest(new ErroDTO("Erro ao remover estoque", "Ocorreu um erro ao remover o estoque"));
            
            return Ok("Estoque Removido");
        }
    }
}
