using bill_api.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace bill_api.Api.Controllers.Bill
{
    [Route("api/bill")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;

        public BillController(IBillService billService)
        {
            _billService = billService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bills = await _billService.GetAll();

            if (bills == null)
            {
                return NotFound();
            }

            return Ok(bills);
        }
    }

}
