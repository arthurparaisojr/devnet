
using Produto.models;

namespace Produto.repositories
{
    public interface IProdutoRepository : IRepository<ProdutoBO>
    {
        Task<IEnumerable<ProdutoBO>> GetByNomeAsync(string nome);
    }
}
