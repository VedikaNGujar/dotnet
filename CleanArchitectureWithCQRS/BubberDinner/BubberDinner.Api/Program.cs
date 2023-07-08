using BubberDinner.Api.Filters;
using BubberDinner.Api.Middlewear;
using BubberDinner.Application.Services;
using BubberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);//added by us

// 2nd approach of ErrorHandling
builder.Services.AddControllers(
    options =>
    options.Filters.Add<ErrorHandlingFilterAttribute>());


var app = builder.Build();

// 1st approach of ErrorHandling
//app.UseMiddleware<ErrorHandlingMiddlewear>();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
