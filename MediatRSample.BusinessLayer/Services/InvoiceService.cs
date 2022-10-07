using MediatRSample.BusinessLayer.Models;
using OperationResults;

namespace MediatRSample.BusinessLayer.Services;

public class InvoiceService : IInvoiceService
{
    public async Task<Result<Invoice>> SaveAsync(InvoiceRequest request)
    {
        await Task.Delay(1000);

        var invoice = new Invoice { Id = Guid.NewGuid() };
        return invoice;
    }
}
