using BillApi.Api.Controllers.Bill;
using BillApi.Application.Services;
using BillApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BillApi.Tests.V1.Controllers
{
    public class BillControllerTests
    {
        private readonly Mock<IBillService> _mockBillService;
        private readonly BillController _billController;

        public BillControllerTests()
        {
            _mockBillService = new Mock<IBillService>();
            _billController = new BillController(_mockBillService.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WhenBillsExist()
        {
            _mockBillService.Setup(service => service.GetAll()).ReturnsAsync(new List<Bill>()); // Retorna una lista vacía

            var result = await _billController.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.IsAssignableFrom<List<Bill>>(okResult.Value);
        }

        [Fact]
        public async Task UpdateStatus_ReturnsOkResult_WhenStatusUpdatedSuccessfully()
        {
            var clientId = "exampleClientId";
            _mockBillService.Setup(service => service.UpdateStatus(clientId)).ReturnsAsync(true);

            var result = await _billController.UpdateStatus(clientId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.True((bool)okResult.Value);
        }

        [Fact]
        public async Task UpdateStatus_ReturnsBadRequest_WhenStatusUpdateFails()
        {
            var clientId = "123";
            _mockBillService.Setup(service => service.UpdateStatus(clientId)).ReturnsAsync(false);

            var result = await _billController.UpdateStatus(clientId);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Failed to update the bill status.", ((dynamic)badRequestResult.Value).message);
        }
    }
}