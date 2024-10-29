using Microsoft.AspNetCore.Mvc;
using Moq;
using Transactions.API.Application.Extensions;
using Transactions.API.Controllers;
using Transactions.API.Services;
using Transactions.API.Services.DTOs;
using Xunit;

namespace Transactions.UnitTests.Controllers
{
    public class TransactionControllerTests
    {
        [Fact]
        public async Task GetById_ShouldReturnOkWithTransaction_WhenTransactionExists()
        {
            int id = 12345;
            var trans = new TransactionDTO(id, "1", 4300, "1");

            var transServices = new Mock<ITransactionService>();

            transServices.Setup(x => x.GetByIdAsync(id)).Returns(Task.FromResult(trans)!);

            var transController = new TransactionsController(transServices.Object);

            var result = await transController.GetById(id);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(trans.ToViewModel(), okResult.Value);
        }

        [Fact]
        public async Task GetById_ShouldReturnNotFound_WhenTransactionDoesNotExists()
        {
            int id = 123456;
            TransactionDTO? trans = null;

            var transService = new Mock<ITransactionService>();

            transService.Setup(x => x.GetByIdAsync(id)).Returns(Task.FromResult(trans));

            var transController = new TransactionsController(transService.Object);

            var result = await transController.GetById(id);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetByIdRecipient_ShouldReturnOkWithTransaction_WhenTransactionExists()
        {
            string IdRecipient = "123456789";
            var trans = new TransactionDTO(123456, IdRecipient, 4500, "11223344");

            var transService = new Mock<ITransactionService>();

            transService.Setup(x => x.GetByIdRecipientAsync(IdRecipient)).Returns(Task.FromResult(trans)!);

            var transController = new TransactionsController(transService.Object);

            var result = await transController.GetByIdRecipient(IdRecipient);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(trans.ToViewModel(), okResult.Value);
        }

        [Fact]
        public async Task GetByIdRecipient_ShouldReturnNotFound_WhenTransactionDoesNotExists()
        {
            string IdRecipient = "123456789";
            TransactionDTO? trans = null;

            var transService = new Mock<ITransactionService>();

            transService.Setup(x => x.GetByIdRecipientAsync(IdRecipient)).Returns(Task.FromResult(trans));

            var transController = new TransactionsController(transService.Object);

            var result = await transController.GetByIdRecipient(IdRecipient);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetByIdsender_ShouldReturnOkWithTransaction_WhenTransactionExists()
        {
            string Idsender = "123456789";
            var trans = new TransactionDTO(123456, "123456789", 4500, Idsender);

            var transService = new Mock<ITransactionService>();

            transService.Setup(x => x.GetByIdsenderAsync(Idsender)).Returns(Task.FromResult(trans)!);

            var transController = new TransactionsController(transService.Object);

            var result = await transController.GetByIdsender(Idsender);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(trans.ToViewModel(), okResult.Value);
        }

        [Fact]
        public async Task GetByIdsender_ShouldReturnNotFound_WhenTransactionDoesNotExists()
        {
            string Idsender = "123456789";
            TransactionDTO? trans = null;

            var transService = new Mock<ITransactionService>();

            transService.Setup(x => x.GetByIdsenderAsync(Idsender)).Returns(Task.FromResult(trans));

            var transController = new TransactionsController(transService.Object);

            var result = await transController.GetByIdsender(Idsender);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
