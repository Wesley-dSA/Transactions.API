namespace Transactions.API.Application.ViewModels;
public record TransactionViewModel(int Id, string IdRecipient, decimal Valor, string Idsender);