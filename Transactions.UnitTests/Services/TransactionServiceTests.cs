using MockQueryable.Moq;
using Moq;
using Transactions.API.Application.Extensions;
using Transactions.API.Infrastructure.Data;
using Transactions.API.Services;
using Transactions.API.Services.Models;
using Xunit;

namespace Transactions.UnitTests.Services;

public class TransactionServiceTests
{
    [Fact]
    public async Task GetById_ShouldReturnTransaction_WhenTransactionExists()
    {
        int id = 123456;

        var trans = new List<Transaction>
        {
            new() { Id = id, Idsender = "123456", Valor = 43510, IdRecipient = "123456789" }
        };

        var mockContext = new Mock<ApplicationDataContext>();
        var transMock = trans.AsQueryable().BuildMockDbSet();

        transMock.Setup(x => x.FindAsync(id)).ReturnsAsync((object[] ids) =>
        {
            var id = (int)ids[0];
            return trans.FirstOrDefault(x => x.Id == id);
        });

        mockContext.Setup(a => a.Transaction).Returns(transMock.Object);

        var transService = new TransactionService(new TransactionRepository(mockContext.Object));

        var result = await transService.GetByIdAsync(id);

        Assert.NotNull(result);
        Assert.Equivalent(trans[0].ToDTO(), result);
    }

    [Fact]
    public async Task GetById_ShouldReturnNull_WhenTransactionDoesNotExists()
    {
        int id = 123456;

        var trans = new List<Transaction>();

        var mockContext = new Mock<ApplicationDataContext>();
        var transMock = trans.AsQueryable().BuildMockDbSet();

        transMock.Setup(x => x.FindAsync(id)).ReturnsAsync((object[] ids) =>
        {
            var id = (int)ids[0];
            return trans.FirstOrDefault(x => x.Id == id);
        });

        mockContext.Setup(a => a.Transaction).Returns(transMock.Object);

        var transService = new TransactionService(new TransactionRepository(mockContext.Object));

        var result = await transService.GetByIdAsync(id);

        Assert.Null(result);
    }

    [Fact]
    public async Task GetByIdRecipient_ShouldReturnTransaction_WhenTransactionExists()
    {
        string IdRecipient = "123456";

        var trans = new List<Transaction>
        {
            new() { Id = 123456, IdRecipient = IdRecipient, Valor = 43510, Idsender = "123456789"}
        };

        var mockContext = new Mock<ApplicationDataContext>();
        var transMock = trans.AsQueryable().BuildMockDbSet();

        mockContext.Setup(a => a.Transaction).Returns(transMock.Object);

        var transService = new TransactionService(new TransactionRepository(mockContext.Object));

        var result = await transService.GetByIdRecipientAsync(IdRecipient);

        Assert.NotNull(result);
        Assert.Equivalent(trans[0].ToDTO(), result);
    }

    [Fact]
    public async Task GetByIdRecipient_ShouldReturnNull_WhenTransactionDoesNotExists()
    {
        string IdRecipient = "123456";

        var trans = new List<Transaction>();

        var mockContext = new Mock<ApplicationDataContext>();
        var transMock = trans.AsQueryable().BuildMockDbSet();

        mockContext.Setup(a => a.Transaction).Returns(transMock.Object);

        var transService = new TransactionService(new TransactionRepository(mockContext.Object));

        var result = await transService.GetByIdRecipientAsync(IdRecipient);

        Assert.Null(result);
    }

    [Fact]
    public async Task GetByIdsender_ShouldReturnTransaction_WhenTransactionExists()
    {
        string Idsender = "123456";

        var trans = new List<Transaction>
        {
            new() { Id = 123456, IdRecipient = "123456 ", Valor = 43510, Idsender = Idsender}
        };

        var mockContext = new Mock<ApplicationDataContext>();
        var transMock = trans.AsQueryable().BuildMockDbSet();

        mockContext.Setup(a => a.Transaction).Returns(transMock.Object);

        var transService = new TransactionService(new TransactionRepository(mockContext.Object));

        var result = await transService.GetByIdsenderAsync(Idsender);

        Assert.NotNull(result);
        Assert.Equivalent(trans[0].ToDTO(), result);
    }

    [Fact]
    public async Task GetByIdsender_ShouldReturnNull_WhenTransactionDoesNotExists()
    {
        string Idsender = "123456";

        var trans = new List<Transaction>();

        var mockContext = new Mock<ApplicationDataContext>();
        var transMock = trans.AsQueryable().BuildMockDbSet();

        mockContext.Setup(a => a.Transaction).Returns(transMock.Object);

        var transService = new TransactionService(new TransactionRepository(mockContext.Object));

        var result = await transService.GetByIdsenderAsync(Idsender);

        Assert.Null(result);
    }
}