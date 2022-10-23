using System;
using System.Collections.Generic;

namespace MobileSaleLibrary.Models
{
    public partial class TblModel
    {
        public TblModel()
        {
            TblPhones = new HashSet<TblPhone>();
        }

        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string ModelOrigin { get; set; }
        public int? ModelYearOfWarranty { get; set; }
        public string ModelBrand { get; set; }

        public virtual ICollection<TblPhone> TblPhones { get; set; }
    }
}
