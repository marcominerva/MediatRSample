using MediatR;
using OperationResults;

namespace MediatRSample.BusinessLayer.Models;

public class InvoiceRequest : IRequest<Result<Invoice>>
{
    public int OrderNumber { get; set; }

    public double Total { get; set; }

    public DateTime Date { get; set; }
}
