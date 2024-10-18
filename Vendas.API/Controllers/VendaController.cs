using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Interfaces;
using Vendas.Application.Services;
using Vendas.Domain.DTOs;

namespace Vendas.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        public VendaController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }


        [HttpGet]
        [Route("listar-todas-vendas")]
        public IActionResult ListarVendas()
        {
            var response = _vendaService.BuscarTodos();
            if (response.Count == 0)
                return NoContent();
            return Ok(response);
        }

        [HttpGet]
        [Route("buscar-vendas-por-data")]
        public IActionResult ListarVendaPorData(DateTime? dataInicio, DateTime? dataFim) 
        {
            var response = _vendaService.BuscarVendasPorData(dataInicio, dataFim);

            if (response.Count == 0)
                return NoContent();
            return Ok(response);
        }

        [HttpGet]
        [Route("buscar-venda-por-id/{id}")]

        public IActionResult BuscarVendaPorId(int id)
        {
            var response = _vendaService.BuscarVendaPorId(id);

            if (response.IdVenda == 0)
                return NoContent();
            return Ok(response);
        }

        [HttpPost]
        [Route("cadastrar-venda")]
        public IActionResult CadastrarVenda([FromBody] VendaInputDTO novaVenda)
        {
            var response = _vendaService.CadastrarVenda(novaVenda);
            if(!response)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPut]
        [Route("atualizar-venda/{id}")]
        public IActionResult AtualizarVenda(int id, [FromBody] VendaAtualizaInputDTO novaVenda)
        {
            if (novaVenda.data_venda == null)
                novaVenda.data_venda = DateTime.MinValue;

            var response = _vendaService.AtualizarVenda(id, novaVenda);
            if (string.IsNullOrEmpty(response))
                return Ok("Venda Atualizada Com Sucesso");
            return BadRequest(response);
        }

        [HttpDelete]
        [Route("remover-venda/{id}")]
        public IActionResult RemoverUsuario(int id)
        {
            var response = _vendaService.RemoverVenda(id);
            if (response)
                return Ok("Venda removida com sucesso");
            return BadRequest("Venda não Localizada");
        }
    }
}
