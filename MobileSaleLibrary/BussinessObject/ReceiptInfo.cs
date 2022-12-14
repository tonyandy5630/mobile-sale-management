using System;
using System.Collections.Generic;

namespace MobileSaleLibrary.Models
{
    public partial class ReceiptInfo
    {
        public int ReceiptId { get; set; }
        public int PhoneId { get; set; }
        public int Quantity { get; set; }
        public int SellPricePerUnit { get; set; }

        public virtual Phone Phone { get; set; }
        public virtual Receipt Receipt { get; set; }
    }
}
