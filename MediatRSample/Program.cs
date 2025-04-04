using MediatRSample.BusinessLayer.Handlers;
using MediatRSample.BusinessLayer.Services;
using OperationResults.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOperationResult();

builder.Services.AddScoped<IInvoiceService, InvoiceService>();

builder.Services.AddMediatR(options =>
{
    _ = options.RegisterServicesFromAssemblyContaining<InvoiceRequestHandler>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
