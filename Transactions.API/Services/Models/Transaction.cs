﻿namespace Transactions.API.Services.Models
{
    public class Transaction
    {
        public string IdTransaction { get; set; }
        public string Idrecipient { get; set; }
        public decimal Valor { get; set; }
        public string Idsender { get; set; }
    }
}

