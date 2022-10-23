using System;
using System.Collections.Generic;

namespace MobileSaleLibrary.Models
{
    public partial class TblImport
    {
        public TblImport()
        {
            TblImportInfos = new HashSet<TblImportInfo>();
        }

        public int ImportId { get; set; }
        public DateTime? ImportDate { get; set; }
        public int? SupplierId { get; set; }

        public virtual TblSupplier Supplier { get; set; }
        public virtual ICollection<TblImportInfo> TblImportInfos { get; set; }
    }
}
