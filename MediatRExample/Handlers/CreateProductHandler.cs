using MediatR;
using MediatRExample.Commands;
using MediatRExample.Models;

namespace MediatRExample.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private static readonly List<Product> Products = new();

        public Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken) 
        {
            var newProduct = new Product { Id = Products.Count + 1, Name = request.Name, Price = request.Price };
            Products.Add(newProduct);
            return Task.FromResult(newProduct); 
        }
    }
}
