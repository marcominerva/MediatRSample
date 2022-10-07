using MediatR;
using MediatR.Pipeline;
using MediatRSample.BusinessLayer.Models;
using MediatRSample.BusinessLayer.Services;
using Microsoft.Extensions.Logging;
using OperationResults;

namespace MediatRSample.BusinessLayer.Handlers;

public class InvoiceRequestHandler : IRequestHandler<InvoiceRequest, Result<Invoice>>, IRequestExceptionHandler<InvoiceRequest, Result<Invoice>>
{
    private readonly IInvoiceService invoiceService;
    private readonly ILogger<InvoiceRequestHandler> logger;

    public InvoiceRequestHandler(IInvoiceService invoiceService, ILogger<InvoiceRequestHandler> logger)
    {
        this.invoiceService = invoiceService;
        this.logger = logger;
    }

    public async Task<Result<Invoice>> Handle(InvoiceRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("{Handler} called. ", nameof(InvoiceRequestHandler));

        var result = await invoiceService.SaveAsync(request);

        if (DateTime.UtcNow.Minute % 2 == 0)
        {
            throw new Exception("Unexpected error");
        }

        return result;
    }

    public Task Handle(InvoiceRequest request, Exception exception, RequestExceptionHandlerState<Result<Invoice>> state, CancellationToken cancellationToken)
    {
        state.SetHandled(Result.Fail(FailureReasons.GenericError, exception));
        return Task.CompletedTask;
    }
}
