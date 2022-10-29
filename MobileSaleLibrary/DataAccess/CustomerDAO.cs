using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileSaleLibrary.Models;

namespace MobileSaleLibrary.DataAccess
{
    public class CustomerDAO
    {
        //do not change id
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
            var customers = new List<Customer>();
            try
            {
                using var context = new SalePhoneMangementContext();
                customers = context.TblCustomers.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customers;
        }

        public Customer GetCustomerByID(int customerID)
        {
            Customer customer = null;
            try
            {
                using var context = new SalePhoneMangementContext();
                customer = context.TblCustomers.SingleOrDefault(c => c.CustomerId == customerID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return customer;
        }

        public bool AddNewCustomer(Customer customer)
        {
            Customer aCustomer;
            try
            {
                if(customer.CustomerId != 0)
                {
                    throw new Exception("Cannot insert ID when add item");
                    return false;
                }
                aCustomer = GetCustomerByID(customer.CustomerId);
                if (aCustomer == null)
                {
                    using var context = new SalePhoneMangementContext();    
                    context.TblCustomers.Add(customer);
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

        public bool updateCustomer(Customer customer)
        {
            Customer aCustomer = null;
            try
            {
                aCustomer = GetCustomerByID(customer.CustomerId);
                if (aCustomer != null)
                {
                    using var context = new SalePhoneMangementContext();
                    context.TblCustomers.Update(customer);
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

        public bool DeleteCustomer(int customerID)
        {
            Customer dCustomer = GetCustomerByID(customerID);
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
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
