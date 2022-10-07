using System.Net.Mime;
using MediatR;
using MediatRSample.BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using OperationResults.AspNetCore;

namespace MediatRSample.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class InvoicesController : ControllerBase
{
    private readonly IMediator mediator;

    public InvoicesController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Invoice))]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Save(InvoiceRequest request)
    {
        var result = await mediator.Send(request);

        var response = HttpContext.CreateResponse(result);
        return response;
    }

    [HttpPost("{id:guid}/notify")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Notify(Guid id)
    {
        await mediator.Publish(new InvoiceNotification { Id = id });
        return NoContent();
    }
}
