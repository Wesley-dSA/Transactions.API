using System.Drawing;

namespace Transactions.API.Services.DTOs
{
    public record TransactionsDTO(string IdTransaction, string Idrecipient, decimal Valor, string Idsender);
}
