using Produto.data;
using Produto.models;

namespace Produto.repositories
{
    public class ProdutoRepository : Repository<ProdutoBO>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<ProdutoBO>> GetByNomeAsync(string nome)
        {
            return await _context.Produtos
                .Where(p => p.Nome.Contains(nome))
                .ToListAsync();
        }
    }
}
