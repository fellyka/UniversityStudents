using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using UniversityStudents.Extensions;

/*
  The builder variable of the type WebApplicationBuilder is created
  The WebApplicationBuilder is responsible of 4 main things:
    - Adding Configuration to the project by using the builder.Configuration property
    - Registering services with the builder.Services property
    - Logging configuration with the buider.Logging property
    - Other IHostBuilder and IWebHostBuilder configuration
 */
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//services from the ServiceExtension class
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
