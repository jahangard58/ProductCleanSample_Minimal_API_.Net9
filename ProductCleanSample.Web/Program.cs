using ProductCleanSample.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

app.UseMiddlewaresAli();

await app.RunAsync();




