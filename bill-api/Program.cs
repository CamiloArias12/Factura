using bill_api.Application.Services;
using bill_api.Persisntace.Repositories;
using bill_api.Persisntace.Seed;
using bill_api.Persisntence.Config;
using bill_api.Persistence.Seeding;
using client_api.Application.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("Hello");

builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));

// Register IMongoClient
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});

// Register IMongoDatabase
builder.Services.AddScoped(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var settings = sp.GetRequiredService<IOptions<MongoSettings>>().Value;
    return client.GetDatabase(settings.Database);
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IBillRepository, BillRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<IBillService, BillService>();
builder.Services.AddScoped<IClientService, ClientService>();


builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var client = scope.ServiceProvider.GetRequiredService<ClientSeeder>();
    await client.SeedAsync();
    var clients = await client.GetAllClientsAsync();

    var billSeeder = scope.ServiceProvider.GetRequiredService<BillSeeder>();
    await billSeeder.SeedAsync(clients);
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
