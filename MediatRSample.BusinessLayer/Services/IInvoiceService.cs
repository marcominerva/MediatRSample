using MediatRSample.BusinessLayer.Models;
using OperationResults;

namespace MediatRSample.BusinessLayer.Services;

public interface IInvoiceService
{
    Task<Result<Invoice>> SaveAsync(InvoiceRequest request);
}