using System;
using System.Collections.Generic;

namespace MobileSaleLibrary.Models
{
    public partial class TblCustomer
    {
        public TblCustomer()
        {
            TblReceipts = new HashSet<TblReceipt>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Gender { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerAddress { get; set; }

        public virtual ICollection<TblReceipt> TblReceipts { get; set; }
    }
}
