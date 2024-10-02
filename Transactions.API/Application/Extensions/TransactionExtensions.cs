using Transactions.API.Services.DTOs;
using Transactions.API.Services.Models;
using Users.API.Application.ViewModels;

namespace Transactions.API.Application.Extensions;

public static class TransactionExtensions
{
    public static IEnumerable<TransactionViewModel> ToViewModel(this IEnumerable<TransactionsDTO> trans)
    {
        return trans.Select(ToViewModel);
    }

    public static TransactionViewModel ToViewModel(this TransactionsDTO trans)
    {
        return new TransactionViewModel(trans.IdTransaction, trans.Idrecipient, trans.Valor, trans.Idsender);
    }

    public static IEnumerable<TransactionsDTO> ToDTO(this IEnumerable<Services.Models.Transactions> trans)
    {
        return trans.Select(ToDTO);
    }

    public static TransactionsDTO ToDTO(this Services.Models.Transactions trans)
    {
        return new TransactionsDTO(trans.IdTransaction, trans.Idrecipient, trans.Valor, trans.Idsender);
    }
}