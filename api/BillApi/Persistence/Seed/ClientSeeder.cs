using BillApi.Domain.Entities;
using MongoDB.Driver;

namespace BillApi.Persistence.Seed
{
    public class ClientSeeder(IMongoDatabase database)
    {
        private readonly IMongoCollection<Client> _clientCollection = database.GetCollection<Client>("Clients");

        public async Task SeedAsync()
        {
            if ((await _clientCollection.CountDocumentsAsync(_ => true)) == 0)
            {
                var clients = new List<Client>
                {
                    new() { Name = "Prueba desarrollo 1",Nit="111.111.111-1", Email = "ariaspira13@gmail.com" },
                    new() { Name = "Prueba desarrollo 2",Nit="222.222.222-2", Email = "ariaspira13@gmail.com" },
                    new() { Name = "Prueba desarrollo 3",Nit="333.333.333-3", Email = "ariaspira13@gmail.com" },
                    new() { Name = "Prueba desarrollo 4",Nit="444.444.444-4", Email = "ariaspira13@gmail.com" },
                    new() { Name = "Prueba desarrollo 5",Nit="555.555.555-5" ,Email = "ariaspira13@gmail.com" }
                };

                await _clientCollection.InsertManyAsync(clients);
            }
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await _clientCollection.Find(_ => true).ToListAsync();
        }
    }
}
