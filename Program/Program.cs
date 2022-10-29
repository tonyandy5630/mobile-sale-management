// See husing System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MobileSaleLibrary.DataAccess;
using MobileSaleLibrary.Models;
using MobileSaleLibrary.Repository;
using MobileSaleLibrary.Repository.IRepository;

namespace Program // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            AddItem();
            UpdateItem(2);
            DeleteItem(2);
            showCustomer();

        }

        private static void AddItem()
        {
            
            try
            {
                Customer customer = new Customer
                {
                    CustomerId = 0,
                    CustomerName = "test2",
                    Gender = "test2",
                    CustomerAddress = "test2",
                    CustomerPhoneNumber = "test2"
                };
                bool check = CustomerDAO.Instance.AddNewCustomer(customer);
                if (check)
                {
                    System.Console.WriteLine("Add success");
                }
                else
                {
                    System.Console.WriteLine("Add Fail");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void UpdateItem(int id)
        {

            try
            {
                Customer customer = new Customer
                {
                    CustomerId = id,
                    CustomerName = "test2",
                    Gender = "test2",
                    CustomerAddress = "test2",
                    CustomerPhoneNumber = "test2"
                };
                bool check = CustomerDAO.Instance.updateCustomer(customer);
                if (check)
                {
                    System.Console.WriteLine("Update success");
                }
                else
                {
                    System.Console.WriteLine("Update Fail");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void showCustomer()
        {
            try
            {
                IEnumerable<Customer> customers = CustomerDAO.Instance.GetCustomerList();
                foreach(Customer customer in customers)
                {
                    System.Console.WriteLine($"ID:{customer.CustomerId}, Name:{customer.CustomerName}, Address:{customer.CustomerAddress}");
                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public static void DeleteItem(int id)
        {
            try
            {
                bool check =  CustomerDAO.Instance.DeleteCustomer(id);
                if (check)
                {
                    System.Console.WriteLine("Delete success");
                }
                else
                {
                    System.Console.WriteLine("Delte Fail");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}