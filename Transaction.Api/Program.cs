using Serilog;
using Transaction.Api.Extensions;
using Transaction.Api.Middlewares;
using Transaction.Application;
using Transaction.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.UseDateOnlyTimeOnlyStringConverters());
builder.Services.AddControllers();
builder.Services.AddDateOnlyTimeOnlyStringConverters();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.ApplyMigrations();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.Run();