using MediatR;
using MediatRExample.Models;

namespace MediatRExample.Notifications
{
    public class ProductCreatedNotification : INotification
    {
        public Product Product { get; set; }

        public ProductCreatedNotification(Product product)
        {
            Product = product;
        }
    }
}
