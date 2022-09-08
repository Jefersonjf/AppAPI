using AppAPI.Model;
using AppAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Usuario>> Get()
        {
            return await _usuarioRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            return await _usuarioRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario([FromBody] Usuario usuario)
        {
            var newUsuario = await _usuarioRepository.Create(usuario);
            return CreatedAtAction(nameof(Usuario), new { id = newUsuario.Id }, newUsuario);
        } 

        [HttpDelete]
        public async Task<ActionResult> Delete(int id, NotFoundResult notFoundResult)
        {
            var usuarioToDelete = await _usuarioRepository.Get(id);

            if (usuarioToDelete == null)
                return NotFound();

            await _usuarioRepository.Delete(usuarioToDelete.Id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] Usuario usuario)
        {
            if (id == usuario.Id)
                return BadRequest();

            await _usuarioRepository.Update(usuario);
            return NoContent();

        }

              
    }
}
