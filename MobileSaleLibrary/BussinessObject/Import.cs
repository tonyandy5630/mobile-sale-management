using System;
using System.Collections.Generic;

namespace MobileSaleLibrary.Models
{
    public partial class Import
    {
        public Import()
        {
            TblImportInfos = new HashSet<ImportInfo>();
        }

        public int ImportId { get; set; }
        public DateTime ImportDate { get; set; }
        public int SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<ImportInfo> TblImportInfos { get; set; }
    }
}
