using System;

namespace OnlineBankingApp.Models
{
    public class AccountActivity
    {
        public int AccountActivityId { get; set; }
        public DateTime ActivityDate { get; set; }
        public double Amount { get; set; }
        public string ActivityType { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
