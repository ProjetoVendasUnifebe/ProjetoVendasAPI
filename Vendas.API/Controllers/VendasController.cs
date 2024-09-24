using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Interfaces;
using Vendas.Domain.DTOs;

namespace Vendas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public VendasController(IUsuarioService usuarioService) 
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Route("buscar-todos-usuarios")]
        public IActionResult BuscarTodosUsuarios()
        {
            var response = _usuarioService.ListarTodosUsuarios();
            if (response.Count == 0)
                return BadRequest( new ErroDTO("Lista Vazia", "Aparentemente a lista esta vazia"));
            return Ok(response);  
        }

        [HttpGet]
        [Route("buscar-usuario-por-id")]
        public IActionResult BuscarUsuarioPorId([FromQuery] int id)
        {
            var response = _usuarioService.BuscarNomeUsuario(id);
            if (response.Nome == null)
                return BadRequest(new ErroDTO("Usuario nao existe", "Aparentemente o usuario que voce busca nao existe"));
            return Ok(response);
        }
    }
}
