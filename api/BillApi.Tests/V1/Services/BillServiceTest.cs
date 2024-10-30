using BillApi.Application.Services;
using BillApi.Domain.Entities;
using BillApi.Infrastructure.Email.Interfaces;
using BillApi.Persistence.Repositories;
using Moq;

namespace BillApi.Tests.V1.Services
{
    public class BillServiceTests
    {
        private readonly Mock<IBillRepository> _mockBillRepository;
        private readonly Mock<IClientService> _mockClientService;
        private readonly Mock<IEmailService> _mockEmailService;
        private readonly BillService _billService;

        public BillServiceTests()
        {
            _mockBillRepository = new Mock<IBillRepository>();
            _mockClientService = new Mock<IClientService>();
            _mockEmailService = new Mock<IEmailService>();
            _billService = new BillService(_mockBillRepository.Object, _mockClientService.Object, _mockEmailService.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsListOfBills_WhenBillsExist()
        {

            var result = await _billService.GetAll();

            Assert.NotNull(result);
            Assert.IsType<List<Bill>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetAll_ReturnsEmptyList_WhenNoBillsExist()
        {
            var result = await _billService.GetAll();

            Assert.NotNull(result);
            Assert.IsType<List<Bill>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task UpdateStatus_ReturnsTrue_WhenBillIsUpdated()
        {
            var clientId = "exampleBillId";

            var result = await _billService.UpdateStatus(clientId);

            Assert.True(result);
        }

    }
}
