using System;
using System.Collections.Generic;

namespace MobileSaleLibrary.Models
{
    public partial class TblReceipt
    {
        public TblReceipt()
        {
            TblReceiptInfos = new HashSet<TblReceiptInfo>();
        }

        public int ReceiptId { get; set; }
        public DateTime ReceiptDate { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<TblReceiptInfo> TblReceiptInfos { get; set; }
    }
}
