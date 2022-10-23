using System;
using System.Collections.Generic;

namespace MobileSaleLibrary.Models
{
    public partial class TblReceiptInfo
    {
        public int ReceiptId { get; set; }
        public int PhoneId { get; set; }
        public int? Quantity { get; set; }
        public string SellPricePerUnit { get; set; }

        public virtual Phone Phone { get; set; }
        public virtual Receipt Receipt { get; set; }
    }
}
