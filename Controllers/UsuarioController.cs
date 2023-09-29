using Microsoft.AspNetCore.Mvc;
using NovaApi2.Models.Domain.Usuario;
using NovaApi2.Repository;
using System;

namespace NovaApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuario;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuario = usuarioRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _usuario.Get();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var usuario = _usuario.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Usuário inválido");
            }

            _usuario.Add(usuario);
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuario usuario)
        {
            if (usuario == null || usuario.Id != id)
            {
                return BadRequest("Dados inválidos");
            }

            var usuarioExistente = _usuario.GetById(id);
            if (usuarioExistente == null)
            {
                return NotFound();
            }

            _usuario.Update(usuario);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuarioExistente = _usuario.GetById(id);
            if (usuarioExistente == null)
            {
                return NotFound();
            }

            _usuario.Delete(usuarioExistente);
            return NoContent();
        }
    }
}
