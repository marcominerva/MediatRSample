using MediatR;

namespace MediatRSample.BusinessLayer.Models;

public class InvoiceNotification : INotification
{
    public Guid Id { get; set; }
}
