using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vendas.API.Controllers
{
        [Route("[controller]")]
        [ApiController]
        public class ViewsController : ControllerBase
        {
            private readonly IViewsService _viewsService;

            public ViewsController(IViewsService viewsService)
            {
                _viewsService = viewsService;
            }


            [HttpGet]
            [Route("buscar-clientes-com-compras")]
            public IActionResult BuscarClientesComCompras(int ordenacao, string? nomeCliente)
            {
                var response = _viewsService.BuscaClientesComCompras(ordenacao, nomeCliente);
                if (!response.Any())
                    return NoContent();
                return Ok(response);
            }

            [HttpGet]
            [Route("buscar-produtos-vendidos")]
            public IActionResult BuscarProdutosVendidos(int ordenacao, string? nomeProduto)
            {
                var response = _viewsService.BuscarProdutosVendidos(ordenacao, nomeProduto);  
                if (!response.Any())
                    return NoContent();
                return Ok(response);
            }

            [HttpGet]
            [Route("buscar-faturamento")]
            public IActionResult BuscarFaturamento(int mes, int ano)
            {
                var response = _viewsService.BuscarFaturamento(mes, ano);
                if (!response.Any())
                    return NoContent();
                return Ok(response);
            }

            [HttpGet]
            [Route("buscar-vendas-finalizadas")]
            public IActionResult BuscarVendasFinalizadas()
            {
                var response = _viewsService.BuscarVendasRealizadas();
                if (!response.Any())
                    return NoContent();
                return Ok(response);
            }
    }
}
