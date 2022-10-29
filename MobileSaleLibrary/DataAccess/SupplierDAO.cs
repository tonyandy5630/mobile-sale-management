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
        private static CustomerDAO instance = null;
        private static readonly object instanceLock = new object();

        public static CustomerDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CustomerDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Customer> GetCustomerList()
        {
            var suppliers = new List<Customer>();
            try
            {
                using var context = new SalePhoneMangementContext();
                suppliers = context.TblCustomers.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return suppliers;
        }

        public Customer GetCustomerByID(int supplierID)
        {
            Customer supplier = null;
            try
            {
                using var context = new SalePhoneMangementContext();
                supplier = context.TblCustomers.SingleOrDefault(c => c.CustomerId == supplierID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return supplier;
        }

        public bool AddNewCustomer(Customer supplier)
        {
            Customer aCustomer;
            try
            {
                if (supplier.CustomerId != 0)
                {
                    throw new Exception("Cannot insert ID when add item");
                    return false;
                }
                aCustomer = GetCustomerByID(supplier.CustomerId);
                if (aCustomer == null)
                {
                    using var context = new SalePhoneMangementContext();
                    context.TblCustomers.Add(supplier);
                    return context.SaveChanges() == 1;
                }
                else
                {
                    throw new Exception("Customer alredy exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool updateCustomer(Customer supplier)
        {
            Customer aCustomer = null;
            try
            {
                aCustomer = GetCustomerByID(supplier.CustomerId);
                if (aCustomer != null)
                {
                    using var context = new SalePhoneMangementContext();
                    context.TblCustomers.Update(supplier);
                    return context.SaveChanges() == 1;
                }
                else
                {
                    throw new Exception("Customer not exist ");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteCustomer(int supplierID)
        {
            Customer dCustomer = GetCustomerByID(supplierID);
            try
            {
                if (dCustomer != null)
                {
                    using var context = new SalePhoneMangementContext();
                    context.Remove(dCustomer);
                    return context.SaveChanges() == 1;
                }
                else
                {
                    throw new Exception("Customer not exist !!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
