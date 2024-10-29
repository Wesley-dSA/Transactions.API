using Transactions.API.Application.Extensions;
using Transactions.API.Services.DTOs;

namespace Transactions.API.Services;

public interface ITransactionService
{
    Task<TransactionDTO?> GetByIdAsync(int Id);
    Task<TransactionDTO?> GetByIdsenderAsync(string Idsender);
    Task<TransactionDTO?> GetByIdRecipientAsync(string IdRecipient);

}

public class TransactionService(ITransactionRepository transactionRepository) : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository = transactionRepository;

    public async Task<TransactionDTO?> GetByIdAsync(int Id)
    {
        var trans = await _transactionRepository.GetByIdAsync(Id);

        return trans?.ToDTO();
    }

    public Task<object?> GetByIdsenderAsync(object Idsender)
    {
        throw new NotImplementedException();
    }

    public async Task<TransactionDTO?> GetByIdsenderAsync(string Idsender)
    {
        var trans = await _transactionRepository.GetByIdsenderAsync(Idsender);

        return trans?.ToDTO();
    }

    public Task<object?> GetByIdRecipientAsync(object IdRecipient)
    {
        throw new NotImplementedException();
    }

    public async Task<TransactionDTO?> GetByIdRecipientAsync(string IdRecipient)
    {
        var trans = await _transactionRepository.GetByIdRecipientAsync(IdRecipient);
        return trans?.ToDTO();
    }
}