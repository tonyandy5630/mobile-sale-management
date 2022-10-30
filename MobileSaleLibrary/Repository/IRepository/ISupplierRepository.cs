using MobileSaleLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSaleLibrary.Repository.IRepository
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetSupplierList();
        bool AddNewSupplier(Supplier supplier);
        bool RemoveSupplier(int id);
        Supplier GetSupplierByID(int id);
        bool UpdateSupplier(Supplier supplier);
    }
}
