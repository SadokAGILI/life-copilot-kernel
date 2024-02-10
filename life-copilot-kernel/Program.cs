using Microsoft.Extensions.Hosting.WindowsServices;
using NLog.Extensions.Logging;

var options = new WebApplicationOptions
{
    Args = args,
    ContentRootPath = WindowsServiceHelpers.IsWindowsService()
    ? AppContext.BaseDirectory : default
};
var builder = WebApplication.CreateBuilder(options);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.ConfigureHostConfiguration(c =>

{

    string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");

    c.AddJsonFile(configFilePath, optional: false, reloadOnChange: true);
    c.AddEnvironmentVariables();

});
builder.WebHost.ConfigureLogging((hostingContext, logging) =>
{
    logging.AddNLog(hostingContext.Configuration.GetSection("Logging"));
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
