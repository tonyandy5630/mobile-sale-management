using MobileSaleLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSaleLibrary.DataAccess
{
    public class SupplierDAO
    {
        // do not touch Id
        private static SupplierDAO instance = null;
        private static readonly object instanceLock = new object();

        public static SupplierDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SupplierDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Supplier> GetSupplierList()
        {
            var suppliers = new List<Supplier>();
            try
            {
                using var context = new SalePhoneMangementContext();
                suppliers = context.TblSuppliers.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return suppliers;
        }

        public Supplier GetSupplierByID(int supplierID)
        {
            Supplier supplier = null;
            try
            {
                using var context = new SalePhoneMangementContext();
                supplier = context.TblSuppliers.SingleOrDefault(c => c.SupplierId == supplierID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return supplier;
        }

        public bool AddNewSupplier(Supplier supplier)
        {
            Supplier aSupplier;
            try
            {
                if (supplier.SupplierId != 0)
                {
                    throw new Exception("Cannot insert ID when add item");
                    return false;
                }
                aSupplier = GetSupplierByID(supplier.SupplierId);
                if (aSupplier == null)
                {
                    using var context = new SalePhoneMangementContext();
                    context.TblSuppliers.Add(supplier);
                    return context.SaveChanges() == 1;
                }
                else
                {
                    throw new Exception("Supplier alredy exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool updateSupplier(Supplier supplier)
        {
            Supplier aSupplier = null;
            try
            {
                aSupplier = GetSupplierByID(supplier.SupplierId);
                if (aSupplier != null)
                {
                    using var context = new SalePhoneMangementContext();
                    context.TblSuppliers.Update(supplier);
                    return context.SaveChanges() == 1;
                }
                else
                {
                    throw new Exception("Supplier not exist ");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteSupplier(int supplierID)
        {
            Supplier dSupplier = GetSupplierByID(supplierID);
            try
            {
                if (dSupplier != null)
                {
                    using var context = new SalePhoneMangementContext();
                    context.Remove(dSupplier);
                    return context.SaveChanges() == 1;
                }
                else
                {
                    throw new Exception("Supplier not exist !!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
