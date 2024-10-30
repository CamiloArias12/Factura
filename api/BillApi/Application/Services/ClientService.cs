using BillApi.Application.Services;
using BillApi.Domain.Entities;
using BillApi.Persistence.Repositories;

namespace client_api.Application.Services
{
    public class ClientService(IClientRepository clientRepository) : Service<Client>(clientRepository), IClientService
    {

    }
}
