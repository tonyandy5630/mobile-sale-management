using System;
using System.Collections.Generic;

namespace MobileSaleLibrary.Models
{
    public partial class Receipt
    {
        public Receipt()
        {
            TblReceiptInfos = new HashSet<ReceiptInfo>();
        }

        public int ReceiptId { get; set; }
        public DateTime ReceiptDate { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<ReceiptInfo> TblReceiptInfos { get; set; }
    }
}
