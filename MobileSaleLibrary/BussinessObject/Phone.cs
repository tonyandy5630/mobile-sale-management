using System;
using System.Collections.Generic;

namespace MobileSaleLibrary.Models
{
    public partial class TblPhone
    {
        public TblPhone()
        {
            TblImportInfos = new HashSet<ImportInfo>();
            TblReceiptInfos = new HashSet<TblReceiptInfo>();
        }

        public int PhoneId { get; set; }
        public int ModelId { get; set; }
        public string Type { get; set; }
        public int ShowPrice { get; set; }

        public virtual Model Model { get; set; }
        public virtual ICollection<ImportInfo> TblImportInfos { get; set; }
        public virtual ICollection<TblReceiptInfo> TblReceiptInfos { get; set; }
    }
}
