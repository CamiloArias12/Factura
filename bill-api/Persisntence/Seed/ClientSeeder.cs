using bill_api.Domain.Entities;
using MongoDB.Driver;

namespace bill_api.Persisntace.Seed
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
                    new() { Name = "Prueba desarrollo 1", Email = "ariaspira13@gmail.com" },
                    new() { Name = "Prueba desarrollo 2", Email = "ariaspira13@gmail.com" },
                    new() { Name = "Prueba desarrollo 3", Email = "ariaspira13@gmail.com" },
                    new() { Name = "Prueba desarrollo 4", Email = "ariaspira13@gmail.com" },
                    new() { Name = "Prueba desarrollo 5", Email = "ariaspira13@gmail.com" }
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
