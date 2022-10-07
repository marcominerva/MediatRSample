using MediatR;
using MediatRSample.BusinessLayer.Models;
using Microsoft.Extensions.Logging;

namespace MediatRSample.BusinessLayer.Handlers;

public class InvoiceNotificationHandler : INotificationHandler<InvoiceNotification>
{
    private readonly ILogger<InvoiceNotificationHandler> logger;

    public InvoiceNotificationHandler(ILogger<InvoiceNotificationHandler> logger)
    {
        this.logger = logger;
    }

    public async Task Handle(InvoiceNotification notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Starting {Handler} for Invoice {Id}...", nameof(InvoiceNotificationHandler), notification.Id);

        await Task.Delay(3000);

        logger.LogInformation("{Handler} ended for Invoice {Id}.", nameof(InvoiceNotificationHandler), notification.Id);
    }
}

public class InvoiceNotificationHandler2 : INotificationHandler<InvoiceNotification>
{
    private readonly ILogger<InvoiceNotificationHandler2> logger;

    public InvoiceNotificationHandler2(ILogger<InvoiceNotificationHandler2> logger)
    {
        this.logger = logger;
    }

    public async Task Handle(InvoiceNotification notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Starting {Handler} for Invoice {Id}...", nameof(InvoiceNotificationHandler2), notification.Id);

        await Task.Delay(3000);

        logger.LogInformation("{Handler} ended for Invoice {Id}.", nameof(InvoiceNotificationHandler2), notification.Id);

    }
}