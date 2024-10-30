using BillApi.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BillApi.Api.Controllers.Bill
{
    [Route("api/bill")]
    [ApiController]
    public class BillController(IBillService billService) : ControllerBase
    {
        private readonly IBillService _billService = billService;

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
        [HttpPost("status/{clientId}")]
        public async Task<IActionResult> UpdateStatus(string clientId)
        {
            var bill = await _billService.UpdateStatus(clientId);

            if (!bill)
            {
                return BadRequest(new { message = "Failed to update the bill status." });
            }
            return Ok(bill);
        }

    }

}
