using AppAPI.Model;
using AppAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Cliente>> Get()
        {
            return await _clienteRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            return await _clienteRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente([FromBody] Cliente cliente)
        {
            var newCliente = await _clienteRepository.Create(cliente);
            return CreatedAtAction(nameof(Cliente), new { id = newCliente.Id }, newCliente );
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCliente(int id)
        {
            var clienteDelete = await _clienteRepository.Get(id);

            if (clienteDelete == null)
                return NotFound();

            await _clienteRepository.Delete(clienteDelete.Id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> PutCliente(int id, [FromBody] Cliente cliente)
        {
            if (id == cliente.Id)
                return BadRequest();

                await _clienteRepository.Update(cliente);

            return NoContent();

        }
    }
}
