using Produto.Controllers;
using Produto.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProdutos
{

    public class ProdutosControllerTests
    {
        private readonly Mock<IProdutoRepository> _mockRepo;
        private readonly ProdutosController _controller;

        public ProdutosControllerTests()
        {
            _mockRepo = new Mock<IProdutoRepository>();
            _controller = new ProdutosController(_mockRepo.Object);
        }

        [Fact]
        public async Task ListarProdutos_RetornaOk()
        {
            _mockRepo.Setup(repo => repo.GetAllAsync())
                     .ReturnsAsync(new List<ProdutoDB>());

            var result = await _controller.ListarProdutos();

            Assert.IsType<OkObjectResult>(result);
        }
    }

}
