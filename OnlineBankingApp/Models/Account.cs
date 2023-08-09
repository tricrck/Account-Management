using System;
using System.Collections.Generic;

namespace OnlineBankingApp.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public int AccountNumber { get; set; }
        public double Balance { get; set; }


        // other properties

        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public ICollection<AccountActivity> AccountActivities { get; set; }
    }
}
