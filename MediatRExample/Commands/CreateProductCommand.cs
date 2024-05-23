using MediatR;
using MediatRExample.Models;

namespace MediatRExample.Commands
{
    public class CreateProductCommand : IRequest<Product>
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public CreateProductCommand(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
