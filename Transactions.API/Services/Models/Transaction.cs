namespace Transactions.API.Services.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string IdRecipient { get; set; }
        public decimal Valor { get; set; }
        public string Idsender { get; set; }
    }
}


