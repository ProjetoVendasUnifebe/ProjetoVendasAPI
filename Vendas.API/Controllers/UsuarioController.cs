using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Specialized;
using Vendas.Application.Interfaces;
using Vendas.Application.Services;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;


        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Route("buscar-todos-usuarios")]
        public IActionResult BuscarUsuarios()
        {
            var response = _usuarioService.BuscarUsuarios();
            if (response.Count == 0)
                return NoContent();
            return Ok(response);
        }

        [HttpGet]
        [Route("buscar-usuario-por-login/{login}")]
        public IActionResult BuscarUsuarioPorLogin(string login)
        {
            var response = _usuarioService.BuscarUsuarioPorLogin(login);

            if (response.IdUsuario != 0)
                return Ok(response);
            return NoContent();
            
        }

        [HttpGet]
        [Route("buscar-usuario-por-id/{id}")]

        public IActionResult BuscarUsuarioPorId(int id)
        {
            var response = _usuarioService.BuscarUsuarioPorId(id);

            if (response.IdUsuario == 0)
                return NoContent();
            return Ok(response);
        }

        [HttpGet]
        [Route("buscar-usuario-por-nome/{nome}")]

        public IActionResult BuscarUsuarioPorNome(string nome)
        {
            var response = _usuarioService.BuscarUsuarioPorNome(nome);

            if (response.Count > 0)
                return Ok(response);
            return NoContent();
        }

        [HttpGet]
        [Route("realizar-login/{login}/{senha}")]
        public IActionResult RealizarLogin(string login, string senha)
        {
            var response = _usuarioService.RealizarLogin(login, senha);
            if (!response)
                return BadRequest(new ErroDTO("Usuario/senha incorreto", "Verifique suas credenciais e tente novamente"));

            return Ok(response);
        }

        [HttpPost]
        [Route("cadastrar-usuario")]

        public IActionResult CadastrarUsuario([FromBody] UsuarioInputDTO novoUsuario)
        {
            var response = _usuarioService.CadastrarUsuario(novoUsuario);

            if (!response)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPut]
        [Route("atualizar-usuario")]
        public IActionResult AtualizarUsuario([FromBody] UsuarioDTO usuarioAtualizado)
        {
            var response = _usuarioService.AtualizarUsuario(usuarioAtualizado);
            if (string.IsNullOrEmpty(response))
                return Ok("Usuario Atualizado Com Sucesso");
            return BadRequest(response);
        }

        [HttpPut]
        [Route("atualizar-senha-usuario/{login}/{novaSenha}")]
        public IActionResult AtualizarSenhaUsuario(string login, string novaSenha)
        {
            var response = _usuarioService.AtualizarSenhaUsuario(login, novaSenha);
            if (string.IsNullOrEmpty(response))
                return Ok("Senha Atualizada Com Sucesso");
            return BadRequest(response);
        }

        [HttpDelete]
        [Route("remover-usuario/{id}")]
        public IActionResult RemoverUsuario(int id)
        {
            var response = _usuarioService.RemoverUsuario(id);
            if (response)
                return Ok(response);
            return BadRequest(response);
        }

    }
}
