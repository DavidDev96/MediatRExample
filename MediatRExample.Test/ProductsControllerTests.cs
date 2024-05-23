
namespace MediatRExample.Test
{
    public class ProductsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly ProductsController _controller;

        public ProductsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new ProductsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetProductById_ReturnsOk_WhenProductExists()
        {
            // Arrange
            var productId = 1;
            var product = new Product {  Id = productId, Name = "Produkt 1", Price = 10.0M };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetProductByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(product);

            // Act
            var result = await _controller.GetProductById(productId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Product>(okResult.Value);
            Assert.Equal(productId, returnValue.Id);
        }
        [Fact]
        public async Task GetProductById_ReturnsNotFound_WhenProductDoesNotExist()
        {
            // Arrange
            var productId = 1;
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetProductByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync((Product)null);

            // Act
            var result = await _controller.GetProductById(productId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CreateProduct_ReturnsCreatedAtAction_WhenProductIsCreated()
        {
            // Arrange
            var createProductCommand = new CreateProductCommand("Product 1", 10.0M);
            var product = new Product { Id = 1, Name = "Product 1", Price = 10.0M };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateProductCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(product);

            // Act
            var result = await _controller.CreateProduct(createProductCommand);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnValue = Assert.IsType<Product>(createdAtActionResult.Value);
            Assert.Equal(product.Name, returnValue.Name);
        }
    }
}
