using Transactions.API.Services.DTOs;
using Transactions.API.Application.ViewModels;
using Transactions.API.Services.Models;

namespace Transactions.API.Application.Extensions;

public static class TransactionExtensions
{
    public static IEnumerable<TransactionViewModel> ToViewModel(this IEnumerable<TransactionDTO> trans)
    {
        return trans.Select(ToViewModel);
    }

    public static TransactionViewModel ToViewModel(this TransactionDTO transaction)
    {
        return new TransactionViewModel(transaction.IdTransaction, transaction.IdRecipient, transaction.Valor, transaction.Idsender);
    }

    public static IEnumerable<TransactionDTO> ToDTO(this IEnumerable<Transaction> trans)
    {
        return trans.Select(ToDTO);
    }

    public static TransactionDTO ToDTO(this Transaction trans)
    {
        return new TransactionDTO(trans.IdTransaction, trans.IdRecipient, trans.Valor, trans.Idsender);
    }
}