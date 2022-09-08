using AppAPI.Model;
using AppAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        public readonly IProdutoRepository _produtoRepository;
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Produto>> Get()
        {
            return await _produtoRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            return await _produtoRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto([FromBody] Produto produto)
        {
            var newProduto = await _produtoRepository.Create(produto);
            return CreatedAtAction(nameof(Produto),new {id = newProduto.Id}, newProduto );
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id, NotFoundResult notFoundResult)
        {
            var produtoToDelete = await _produtoRepository.Get(id);

            if (produtoToDelete == null)
                return NotFound(); 

               await _produtoRepository.Delete(produtoToDelete.Id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id,[FromBody] Produto produto)
        {
            if (id == produto.Id)
                return BadRequest();

            await _produtoRepository.Update(produto);

            return NoContent();

            
        }



    }
}
