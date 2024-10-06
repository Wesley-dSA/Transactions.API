namespace Transactions.API.Application.ViewModels;
public record TransactionViewModel(string IdTransaction, string IdRecipient, decimal Valor, string Idsender);