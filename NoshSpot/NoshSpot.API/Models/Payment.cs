using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoshSpot.API.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public decimal AmountDue { get; set; }

        public virtual Order Order { get; set; }
    }
}