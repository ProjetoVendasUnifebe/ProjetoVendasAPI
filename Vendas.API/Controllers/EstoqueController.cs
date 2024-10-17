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
                return BadRequest(new ErroDTO("Lista Vazia", "Aparentemente a lista de estoques esta vazia"));
            return Ok(response);
        }

        [HttpGet("estoque-por-id/{id}")]
        public IActionResult BuscarEstoquePorId(int id)
        {
            var estoque = _estoqueService.BuscarEstoquePorId(id);
            if (estoque == null)
                return BadRequest(new ErroDTO("Estoque não encontrado", "O estoque não foi encontrado"));
            return Ok(estoque);
        }

        [HttpGet("estoque-por-nome/{nomeEstoque}")]
        public IActionResult BuscarEstoquePorNome(string nomeEstoque)
        {
            var response = _estoqueService.BuscarEstoquePorNome(nomeEstoque);
            if (response == null)
                return BadRequest(new ErroDTO("Estoque não encontrado", "O estoque não foi encontrado"));
            return Ok(response);
        }

        [HttpPost]
        [Route("adicionar-estoque")]
        public IActionResult AdicionarEstoque([FromBody] EstoqueModel estoque)
        {
           
            var response = _estoqueService.AdicionarEstoque(estoque);
            if (response == false)
                return BadRequest(new ErroDTO("Erro ao adicionar estoque", "Ocorreu um erro ao adicionar o estoque"));
            return Ok("Estoque Adicionado");
            
        }

        [HttpPut]
        [Route("atualizar-estoque")]
        public IActionResult AtualizarEstoque([FromBody] EstoqueModel estoque)
        {
            var response = _estoqueService.AtualizarEstoque(estoque);
            if (response == false)
                return BadRequest(new ErroDTO("Erro ao atualizar estoque", "Ocorreu um erro ao atualizar o estoque"));
            return Ok("Estoque Atualizado");
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
