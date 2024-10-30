using BillApi.Application.Common.Dto;
using BillApi.Domain.Entities;
using BillApi.Infrastructure.Email;
using BillApi.Infrastructure.Email.Interfaces;
using BillApi.Persistence.Repositories;

namespace BillApi.Application.Services
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
                if (bill.Status == EnumStatusBill.FirstReminder.ToFriendlyString())
                {
                    bill.Status = EnumStatusBill.SecondReminder.ToFriendlyString();
                }
                else if (bill.Status == EnumStatusBill.SecondReminder.ToFriendlyString())
                {
                    bill.Status = EnumStatusBill.Disabled.ToFriendlyString();
                }
                else
                {
                    continue;
                }
                var EmailStatusDto = new EmailStatusDto
                {
                    Email = client.Email,
                    Name = client.Name,
                    Status = bill.Status,
                    BillCode = bill.BillCode,

                };
                var SendMail = await SendEmailStatus(EmailStatusDto);
                if (!SendMail)
                {
                    return false;
                }
                await _billRepository.Update(bill.Id, bill);


            }
            return true;
        }
        public async Task<bool> SendEmailStatus(EmailStatusDto emailStatusDto)
        {
            var emailDTO = new EmailDTO
            {
                To = emailStatusDto.Email,
                Subject = "Estado factura",
                Body = $@"
                <h1>Hola, {emailStatusDto.Name}!</h1>
                <p>El estado de tu factura  {emailStatusDto.BillCode} ha cambiado a {emailStatusDto.Status} </p>"
            };

            return await _emailService.SendEmail(emailDTO);

        }

    }
}
