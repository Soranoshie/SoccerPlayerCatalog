using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SoccerPlayerCatalog.DAL;
using SoccerPlayerCatalog.Infrastructure;
using SoccerPlayerCatalog.SchemaFilters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(op =>
{
    op.SwaggerDoc("v1", new OpenApiInfo { Title = "SoccerPlayerCatalogAPI", Version = "v1" });
    var basePath = Environment.CurrentDirectory;
    var xmlPath = Path.Combine(basePath, "XMLFile.xml");
    op.IncludeXmlComments(xmlPath);

    op.SchemaFilter<EnumTypesSchemaFilter>(xmlPath);
});

builder.Services.AddSingleton(new Config(builder.Environment.IsDevelopment()));
builder.Services.RegisterModules();
builder.Services.AddSignalR();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHub<SoccerPlayerHub>("/hub");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.UseWebSockets();

app.MapBlazorHub();

app.MapControllers();

app.MapFallbackToPage("/_Host");

app.Run();