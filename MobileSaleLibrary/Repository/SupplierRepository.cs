using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileSaleLibrary.DataAccess;
using MobileSaleLibrary.Models;
using MobileSaleLibrary.Repository.IRepository;

namespace MobileSaleLibrary.Repository
{

    public class SupplierRepository : ISupplierRepository
    {
        public IEnumerable<Supplier> GetSupplierList() => SupplierDAO.Instance.GetSupplierList();
        public Supplier GetSupplierByID(int id) => SupplierDAO.Instance.GetSupplierByID(id);
        public bool AddNewSupplier(Supplier supplier) => SupplierDAO.Instance.AddNewSupplier(supplier);
        public bool UpdateSupplier(Supplier supplier) => SupplierDAO.Instance.updateSupplier(supplier);
        public bool RemoveSupplier(int id) => SupplierDAO.Instance.DeleteSupplier(id);
    }
}
