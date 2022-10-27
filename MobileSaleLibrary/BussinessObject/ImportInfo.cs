using System;
using System.Collections.Generic;

namespace MobileSaleLibrary.Models
{
    public partial class ImportInfo
    {
        public int ImportId { get; set; }
        public int PhoneId { get; set; }
        public int? Quantity { get; set; }
        public int? BuyPricePerUnit { get; set; }

        public virtual Import Import { get; set; }
        public virtual Phone Phone { get; set; }
    }
}
