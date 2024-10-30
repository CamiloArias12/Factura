using BillApi.Application.Services;
using BillApi.Infrastructure.Email;
using BillApi.Infrastructure.Email.Interfaces;
using BillApi.Persistence.Repositories;
using BillApi.Persistence.Seed;
using BillApi.Persistence.Seeding;
using client_api.Application.Services;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using BillApi.Persisntence.Config;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});

builder.Services.AddScoped(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var settings = sp.GetRequiredService<IOptions<MongoSettings>>().Value;
    return client.GetDatabase(settings.Database);
});

builder.Services.Configure<SmtpConfig>(builder.Configuration.GetSection("EmailConfiguration"));
builder.Services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<SmtpConfig>>().Value);
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IBillRepository, BillRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<IBillService, BillService>();
builder.Services.AddScoped<IClientService, ClientService>();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
builder.Services.AddTransient<BillSeeder>();
builder.Services.AddTransient<ClientSeeder>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "API documentation"
    });
});
var app = builder.Build();

//Seeders
using (var scope = app.Services.CreateScope())
{
    var client = scope.ServiceProvider.GetRequiredService<ClientSeeder>();
    await client.SeedAsync();
    var clients = await client.GetAllClientsAsync();

    var billSeeder = scope.ServiceProvider.GetRequiredService<BillSeeder>();
    await billSeeder.SeedAsync(clients);
}

app.UseSwagger();
app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            c.RoutePrefix = string.Empty;
        });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors();

app.Run();
