using Microsoft.AspNetCore.Mvc;
using NovaApi2.Models.Domain.Usuario;
using NovaApi2.Repository;
using System;
using System.Linq.Expressions;
// usuarioooss
namespace NovaApi2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioController(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
        {
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            var usuarios = _usuarioRepository.Get();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetUsuarioById(int id)
        {
            var usuario = _usuarioRepository.GetById(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult AddUsuario(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Add(usuario);
                _unitOfWork.Commit();

                return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.Id }, usuario);
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                return StatusCode(500, "Ocorreu um erro ao adicionar o usuário.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            try
            {
                _usuarioRepository.Update(usuario);
                _unitOfWork.Commit();

                return NoContent();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                return StatusCode(500, "Ocorreu um erro ao atualizar o usuário.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            var usuario = _usuarioRepository.GetById(id);

            if (usuario == null)
            {
                return NotFound();
            }

            try
            {
                _usuarioRepository.Delete(usuario);
                _unitOfWork.Commit();

                return NoContent();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                return StatusCode(500, "Ocorreu um erro ao excluir o usuário.");
            }
        }
    }
}
