using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Interfaces;
using Vendas.Application.Services;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItensVendidosController : ControllerBase
    {
        private readonly IItensVendidosService _itensVendidosService;

        public ItensVendidosController(IItensVendidosService itensVendidosService)
        {
            _itensVendidosService = itensVendidosService;
        }
        [HttpGet]
        [Route("listar-todos-itens-vendidos")]
        public IActionResult BuscarTodosItensVendidos()
        {
            var response = _itensVendidosService.BuscarTodosItensVendidos();
            if (response.Count() == 0)
                return NoContent();
            return Ok(response);
        }

        [HttpGet]
        [Route("buscar-itens-vendidos-por-id/{id}")]
        public IActionResult BuscarItensVendidosPorId(int id)
        {
            var itensVendidos = _itensVendidosService.BuscarItensVendidosPorId(id);
            if (itensVendidos == null)
                return NoContent();
            return Ok(itensVendidos);
        }

        [HttpPost]
        [Route("adicionar-itens-vendidos")]
        public IActionResult CadastrarItensVendidos([FromBody] ItensVendidosInputDTO itensVendidos)
        {
            var response = _itensVendidosService.CadastrarItensVendidos(itensVendidos);
            if (!response)
                return BadRequest("Não foi possivel cadastrar o ItensVendidos");
            return Ok("ItensVendidos Adicionado");
        }

        [HttpPut]
        [Route("atualizar-itens-vendidos/{id}")]
        public IActionResult AtualizarItensVendidos(int id, [FromBody] ItensVendidosInputDTO itensVendidos)
        {
            var response = _itensVendidosService.AtualizarItensVendidos(id, itensVendidos);
            if (string.IsNullOrEmpty(response))
                return Ok("ItensVendidos Atualizado Com Sucesso");
            return BadRequest(response);
        }

        [HttpDelete]
        [Route("remover-itens-vendidos/{id}")]
        public IActionResult RemoverItensVendidos(int id)
        {
            var response = _itensVendidosService.RemoverItensVendidos(id);
            if (response)
                return Ok("ItensVendidos removido com sucesso");
            return BadRequest("ItensVendidos não Localizado");
        }
    }
}
