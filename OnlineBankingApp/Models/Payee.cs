using System;

namespace OnlineBankingApp.Models
{
    public class Payee
    {
        public int PayeeId { get; set; }
        public string PayeeName { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }

        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
