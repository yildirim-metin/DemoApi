using DemoApi.BLL.Services;
using DemoApi.BLL.Services.Interfaces;
using DemoApi.DAL.Repositories;
using DemoApi.DAL.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

EnvironmentFileReader envReader = new();
envReader.Load();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<BookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "OpenApi V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
