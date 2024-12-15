using Microsoft.AspNetCore.Mvc;
using Produto.repositories;

using Produto.models;
using Produtos.validation;
namespace Produto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _repository;

        public ProdutosController(IProdutoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CriarProduto([FromBody] ProdutoBO produto)
        {
            var validator = new ProdutoValidator();
            var result = validator.Validate(produto);

            if (!result.IsValid)
                return BadRequest(result.Errors);

            await _repository.AddAsync(produto);
            return CreatedAtAction(nameof(ObterProdutoPorId), new { id = produto.Id }, produto);
        }

        [HttpGet]
        public async Task<IActionResult> ListarProdutos()
        {
            var produtos = await _repository.GetAllAsync();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterProdutoPorId(int id)
        {
            var produto = await _repository.GetByIdAsync(id);
            if (produto == null)
                return NotFound();
            return Ok(produto);
        }
    }

}
