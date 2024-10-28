using bill_api.Domain.Entities;
using bill_api.Persisntace.Repositories;
namespace bill_api.Application.Services
{
    public class BillService(IBillRepository billRepository) : Service<Bill>(billRepository), IBillService
    {

    }
}
