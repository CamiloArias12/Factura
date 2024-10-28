using bill_api.Domain.Entities;
using bill_api.Infrastructure.Email.Interfaces;
using bill_api.Persisntace.Repositories;
namespace bill_api.Application.Services
{
    public class BillService(IBillRepository billRepository, IClientService clientService, IEmailService emailService) : Service<Bill>(billRepository), IBillService
    {
        private readonly IBillRepository _billRepository = billRepository;
        private readonly IEmailService _emailService = emailService;
        private readonly IClientService _clientService = clientService;

        public async Task<List<Bill>> GetByClientId(string clientId)
        {
            return await _billRepository.FindByIdClient(clientId);
        }

        public async Task<bool> UpdateStatus(string clientId)
        {
            var client = await _clientService.GetById(clientId);

            if (client == null)
            {
                return false;
            }
            var bills = await GetByClientId(clientId);

            if (bills == null || bills.Count == 0)
            {
                return false;
            }

            foreach (var bill in bills)
            {
                if (bill.Status == "primerrecor")
                {
                    await _emailService.SendEmail(client.Email, "Estado Factura", "");
                }
                else if (bill.Status == "segundorecor")
                {
                    bill.Status = "";
                }
                else
                {
                    continue;
                }
                await _billRepository.Update(bill.Id, bill);

            }
            return true;
        }

    }
}
