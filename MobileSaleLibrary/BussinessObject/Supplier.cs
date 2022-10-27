using System;
using System.Collections.Generic;

namespace MobileSaleLibrary.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            TblImports = new HashSet<Import>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierPhoneNumber { get; set; }
        public string SupplierAddress { get; set; }

        public virtual ICollection<Import> TblImports { get; set; }
    }
}
