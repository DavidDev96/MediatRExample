using MediatR;
using MediatRExample.Models;
using MediatRExample.Queries;

namespace MediatRExample.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private static readonly List<Product> Products = [
            new Product { Id = 1, Name = "Product 1", Price = 0.99M },
            new Product { Id = 2, Name = "Product 2", Price = 1.99M },
            new Product { Id = 3, Name = "Product 3", Price = 2.99M },
            new Product { Id = 4, Name = "Product 4", Price = 3.99M }
        ];

        public Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = Products.FirstOrDefault(p => p.Id == request.Id);
            return Task.FromResult(product);
        }
    }
}
