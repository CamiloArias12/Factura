using bill_api.Application.Common.Dto;
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
                    var client = clients[random.Next(clients.Count)];
                    var status = random.Next(0, 2) == 1;
                    var creationDate = DateTime.UtcNow.AddDays(-random.Next(1, 30));
                    var paymentDate = status ? creationDate.AddDays(random.Next(1, 15)) : (DateTime?)null;

                    var bill = new Bill
                    {
                        ClientId = client.Id,
                        BillCode = $"P-{(i + 1).ToString().PadLeft(5, '0')}",
                        InvoiceTotal = random.Next(10000, 50000),
                        Subtotal = random.Next(8000, 40000),
                        VAT = random.Next(1000, 10000),
                        Withholding = random.Next(0, 5000),
                        CreationDate = creationDate,
                        Status = status ? EnumStatusBill.FirstReminder.ToFriendlyString() : EnumStatusBill.SecondReminder.ToFriendlyString(),
                        City = GetRandomCity(),
                        IsPaid = status,
                        PaymentDate = paymentDate
                    };

                    bills.Add(bill);
                }

                await _billCollection.InsertManyAsync(bills);
            }
        }

        private static string GetRandomCity()
        {
            var cities = new List<string> { "Bogota", "Medellin", "Cali", "Cartagena", "Barranquilla" };
            var random = new Random();
            return cities[random.Next(cities.Count)];
        }
    }
}
