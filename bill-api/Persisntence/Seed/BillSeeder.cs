using bill_api.Domain.Entities;
using MongoDB.Driver;

namespace bill_api.Persistence.Seeding
{
    public class BillSeeder(IMongoDatabase database)
    {
        private readonly IMongoCollection<Bill> _billCollection = database.GetCollection<Bill>("Bills");

        public async Task SeedAsync(List<Client> clients)
        {
            if ((await _billCollection.CountDocumentsAsync(_ => true)) == 0)
            {
                var bills = new List<Bill>();
                var random = new Random();

                for (int i = 0; i < 10; i++)
                {
                    var client = clients[random.Next(clients.Count)]; // Selecciona un cliente aleatorio
                    var isPaid = random.Next(0, 2) == 1; // Aleatoriamente determina si está pagada
                    var creationDate = DateTime.UtcNow.AddDays(-random.Next(1, 30)); // Fecha de creación aleatoria en el último mes
                    var paymentDate = isPaid ? creationDate.AddDays(random.Next(1, 15)) : (DateTime?)null;

                    var bill = new Bill
                    {
                        ClientId = client.Id,
                        InvoiceCode = $"P-{(i + 1).ToString().PadLeft(5, '0')}", // Formato P-00001, P-00002, etc.
                        InvoiceTotal = random.Next(10000, 50000), // Total aleatorio
                        Subtotal = random.Next(8000, 40000), // Subtotal aleatorio
                        VAT = random.Next(1000, 10000), // IVA aleatorio
                        Withholding = random.Next(0, 5000), // Retención aleatoria
                        CreationDate = creationDate,
                        Status = isPaid ? "paid" : "unpaid",
                        City = GetRandomCity(), // Método para obtener una ciudad aleatoria
                        IsPaid = isPaid,
                        PaymentDate = paymentDate
                    };

                    bills.Add(bill);
                }

                await _billCollection.InsertManyAsync(bills);
            }
        }

        private string GetRandomCity()
        {
            var cities = new List<string> { "Bogota", "Medellin", "Cali", "Cartagena", "Barranquilla" };
            var random = new Random();
            return cities[random.Next(cities.Count)];
        }
    }
}
