using Microsoft.EntityFrameworkCore;
using Transactions.API.Infrastructure.Data;
using Transactions.API.Services.DTOs;
using Transactions.API.Services.Models;

namespace Transactions.API.Services;

public interface ITransactionRepository
{
    Task<Transaction?> GetByIdAsync(int Id);
    Task<Transaction?> GetByIdsenderAsync(string Idsender);

    Task<Transaction?> GetByIdRecipientAsync(string Idrecipient);
}

public class TransactionRepository(ApplicationDataContext dataContext) : ITransactionRepository
{
    private readonly DbSet<Transaction> _transaction = dataContext.Transaction; 

    public async Task<Transaction?> GetByIdAsync(int Id)
    {
        return await _transaction.FindAsync(Id);
    }

    public async Task<Transaction?> GetByIdsenderAsync(string Idsender)
    {
        return await _transaction.AsNoTracking().FirstOrDefaultAsync(u => u.Idsender == Idsender);
    }

    public async Task<Transaction?> GetByIdRecipientAsync(string IdRecipient)
    {
        return await _transaction.AsNoTracking().FirstOrDefaultAsync(u => u.IdRecipient == IdRecipient);
    }
}