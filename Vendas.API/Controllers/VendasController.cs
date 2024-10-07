using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Interfaces;
using Vendas.Domain.DTOs;

namespace Vendas.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IProdutoService _produtoService;

        public VendasController(IUsuarioService usuarioService, IProdutoService produtoService)
        {
            _usuarioService = usuarioService;
            _produtoService = produtoService;
        }

        [HttpGet]
        [Route("buscar-usuarios")]
        public IActionResult BuscarUsuarios()
        {
            var response = _usuarioService.BuscarUsuarios();
            if (response.Count == 0)
                return BadRequest(new ErroDTO("Lista Vazia", "Aparentemente a lista esta vazia"));
            return Ok(response);
        }

        [HttpGet]
        [Route("buscar-produtos")]
        public IActionResult BuscarProdutos()
        {
            var response = _produtoService.BuscarProdutos();
            if (response.Count == 0)
                return BadRequest(new ErroDTO("Lista Vazia", "Aparentemente a lista de produtos esta vazia"));
            return Ok(response);
        }
    }
}