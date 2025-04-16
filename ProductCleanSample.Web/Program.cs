using ProductCleanSample.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

app.UseMiddlewaresAli();

await app.RunAsync();


/// <summary> *CLI Commands In Pakage Manager Console
/// *Default project: ProductCleanSample.Catalog.Infrastructure*
/// PM> dotnet tool update --global dotnet-ef
/// PM> dotnet --version
/// PM> dotnet ef --version   //version ef tool Cli
/// PM> dotnet ef dbcontext list -s ProductCleanSample.Web   //list Context ha ra namayesh midahad
/// PM> dotnet ef Migrations add InitRun -s ProductCleanSample.Web     // -s yani stratUp Project set mishavad
/// PM> dotnet ef database update -s ProductCleanSample.Web           
/// </summary> *Run Project And https://localhost:7032/scalar/*

