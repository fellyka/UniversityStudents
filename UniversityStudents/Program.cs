using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;

using NLog;

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

//Logging
//LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config")); //Obsolete
LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));




// Add services to the container.

//services from the ServiceExtension class
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();

/* No View, No Page needed for an API */
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

if(app.Environment.IsDevelopment())
    {
    app.UseDeveloperExceptionPage();
    }
else
    {
    /* This will add the Strict-Transport-Security header */
        app.UseHsts();
    }
app.UseHttpsRedirection();
app.UseStaticFiles();

/* Forward proxy headers to the current request 
   Important during application deployment
 */
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
