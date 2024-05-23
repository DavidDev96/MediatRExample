using MediatR;
using MediatRExample.Models;

namespace MediatRExample.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; } 
        public GetProductByIdQuery(int id) 
        {
            Id = id;
        }
    }
}
