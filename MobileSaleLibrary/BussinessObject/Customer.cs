using System;
using System.Collections.Generic;

namespace MobileSaleLibrary.Models
{
    public partial class Customer
    {
        public Customer()
        {
            TblReceipts = new HashSet<Receipt>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Gender { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerAddress { get; set; }

        public virtual ICollection<Receipt> TblReceipts { get; set; }
    }
}
