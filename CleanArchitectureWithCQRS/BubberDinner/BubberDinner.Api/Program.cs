using BubberDinner.Api.Middlewear;
using BubberDinner.Application.Services;
using BubberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);//added by us

builder.Services.AddControllers();


var app = builder.Build();

// 1st approach of ErrorHandling
app.UseMiddleware<ErrorHandlingMiddlewear>();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
