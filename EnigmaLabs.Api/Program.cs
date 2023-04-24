using Enigma.Api.Extensions;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// open 5000, 5001 ports
builder.WebHost.UseUrls(new string[] { "http://0.0.0.0:5000", "https://0.0.0.0:5001" });

builder.Host.ConfigureAppConfiguration((hostingContent, config) =>
{
    config.SetBasePath(hostingContent.HostingEnvironment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables();
});

var services = builder.Services;

services.AddEndpointsApiExplorer();

services.AddHealthChecks();

services.ConfigureAuthentication(builder.Configuration);

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

services.AddControllersWithViews();

services.ConfigureSqlServer(builder.Configuration);

services.ConfigureDependencyInjection();

services.AddControllers();

services.ConfigureSwagger();
services.ConfigureHangfire(builder.Configuration);

var CorsPolicyName = "_myAllowSpecificOrigins";
services.ConfigureCors(CorsPolicyName);

var app = builder.Build();

var env = app.Environment;

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Numion.Api v1"));
}

app.ConfigureHttpLogging();

app.UseStaticFiles();

app.AppUserCors(CorsPolicyName);

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    if (env.IsDevelopment())
    {
        endpoints.MapControllers();
        //endpoints.MapControllers().AllowAnonymous();
        //
    }
    else
    {
        endpoints.MapControllers();
    }
    endpoints.MapHangfireDashboard();
});

app.UseHangfire();

app.MapFallbackToFile("index.html");

app.Run();