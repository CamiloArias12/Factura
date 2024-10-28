using bill_api.Domain.Entities;
using MongoDB.Driver;

namespace bill_api.Persisntace.Seed
{
    public class ClientSeeder
    {
        private readonly IMongoCollection<Client> _clientCollection;

        public ClientSeeder(IMongoDatabase database)
        {
            _clientCollection = database.GetCollection<Client>("Clients");
        }

        public async Task SeedAsync()
        {
            if ((await _clientCollection.CountDocumentsAsync(_ => true)) == 0)
            {
                var clients = new List<Client>
                {
                    new Client { Name = "Prueba desarrollo 1", Email = "cliente1@ejemplo.com" },
                    new Client { Name = "Prueba desarrollo 2", Email = "cliente2@ejemplo.com" },
                    new Client { Name = "Prueba desarrollo 3", Email = "cliente3@ejemplo.com" },
                    new Client { Name = "Prueba desarrollo 4", Email = "cliente4@ejemplo.com" },
                    new Client { Name = "Prueba desarrollo 5", Email = "cliente5@ejemplo.com" }
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
