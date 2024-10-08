using System.Drawing;

namespace Transactions.API.Services.DTOs
{
    public record TransactionDTO(int Id, string IdRecipient, decimal Valor, string Idsender);
}
