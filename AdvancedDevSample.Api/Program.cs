
using AdvancedDevSample.Application.Services;
using AdvancedDevSample.Domain.Interfaces.Products;
using AdvancedDevSample.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.AddSwaggerGen(options =>
//{
//    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

//    options.IncludeXmlComments(xmlPath);
//});

//builder.Services.AddSwaggerGen(options =>
//{
//    var basePath = AppContext.BaseDirectory;
//    options.IncludeXmlComments(Path.Combine(basePath, "AdvancedDevSample.Api.xml"));
//    options.IncludeXmlComments(Path.Combine(basePath, "AdvancedDevSample.Application.xml"));
//});

builder.Services.AddSwaggerGen(options =>
{
    var basePath = AppContext.BaseDirectory;

    foreach (var xmlFile in Directory.GetFiles(basePath, "*.xml"))
    {
        options.IncludeXmlComments(xmlFile);
    }
});

// ===== Dépendances Application =====
builder.Services.AddScoped<ProductService>();

// ===== Dépendances Infrastructure =====
builder.Services.AddScoped<IProductRepository, EfProductRepository>();

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
