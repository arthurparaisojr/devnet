using Produto.models;
using System.Collections.Generic;

namespace Produto.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ProdutoBO> Produtos { get; set; }
    }
}
