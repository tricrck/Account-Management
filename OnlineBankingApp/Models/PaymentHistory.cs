using System;

namespace OnlineBankingApp.Models
{
    public class PaymentHistory
    {
        public int PaymentHistoryId { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public int PayeeId { get; set; }
        public Payee Payee { get; set; }

        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
