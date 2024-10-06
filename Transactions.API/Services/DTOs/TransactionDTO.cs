using System.Drawing;

namespace Transactions.API.Services.DTOs
{
    public record TransactionDTO(string IdTransaction, string IdRecipient, decimal Valor, string Idsender);
}
