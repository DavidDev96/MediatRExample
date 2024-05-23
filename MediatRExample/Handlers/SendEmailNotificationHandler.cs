using MediatR;
using MediatRExample.Notifications;

namespace MediatRExample.Handlers
{
    public class SendEmailNotificationHandler : INotificationHandler<ProductCreatedNotification>
    {
        private readonly ILogger<SendEmailNotificationHandler> _logger;

        public SendEmailNotificationHandler(ILogger<SendEmailNotificationHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductCreatedNotification notification, CancellationToken cancellationToken) 
        {
            _logger.LogInformation($"Sending email for product: {notification.Product.Name}", cancellationToken);
            // Process. ...

            return Task.CompletedTask;
        }
    }
}
