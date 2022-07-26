#region References
using Microsoft.OpenApi.Models;
using Pagination.Interfaces;
using Pagination.Repositories;
using Pagination.Services;
using System.Reflection;
#endregion

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1.0", new OpenApiInfo
    {
        Version = "v1.0",
        Title = "Pagination API",
        Description = "Api realizado con el fin de mostrar las paginación en los API y los link autogenerados" +
        "para acceder a las paginación, esto esta realizado en .NET 6 </br></br><u>Info:</u></br></br><b>Developer:</b> Darwin José Lugo Mota <b></br></br>Telefone:</b> +584126042751</br>",
        Contact = new OpenApiContact
        {
            //Name = "",
            Email = "darwin_lugo_mota@hotmail.com",
            //Url = new Uri("http://www.primercodigo.com")
        }
    });
    var baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
    var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
    c.IncludeXmlComments(xmlPath);
    c.ResolveConflictingActions(a => a.First());
});

//Injection
builder.Services.AddSingleton<IRepository, Repository>();
builder.Services.AddTransient<IUserServices, UserServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint($"/swagger/v1.0/swagger.json", "Pagination API V1.0");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
