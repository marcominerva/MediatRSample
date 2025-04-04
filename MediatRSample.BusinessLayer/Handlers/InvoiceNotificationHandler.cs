using MediatR;
using MediatRSample.BusinessLayer.Models;
using Microsoft.Extensions.Logging;

namespace MediatRSample.BusinessLayer.Handlers;

public class InvoiceNotificationHandler(ILogger<InvoiceNotificationHandler> logger) : INotificationHandler<InvoiceNotification>
{
    public async Task Handle(InvoiceNotification notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Starting {Handler} for Invoice {Id}...", nameof(InvoiceNotificationHandler), notification.Id);

        try
        {
            await Task.Delay(3000, cancellationToken);

            logger.LogInformation("{Handler} ended for Invoice {Id}.", nameof(InvoiceNotificationHandler), notification.Id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in {Handler} for Invoice {Id}.", nameof(InvoiceNotificationHandler), notification.Id);
        }
    }
}

public class InvoiceNotificationHandler2(ILogger<InvoiceNotificationHandler2> logger) : INotificationHandler<InvoiceNotification>
{
    public async Task Handle(InvoiceNotification notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Starting {Handler} for Invoice {Id}...", nameof(InvoiceNotificationHandler2), notification.Id);

        try
        {
            await Task.Delay(3000, cancellationToken);

            logger.LogInformation("{Handler} ended for Invoice {Id}.", nameof(InvoiceNotificationHandler2), notification.Id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in {Handler} for Invoice {Id}.", nameof(InvoiceNotificationHandler), notification.Id);
        }
    }
}