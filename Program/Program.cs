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
            //AddPhone();
            //addRecipt();
            //updateRecipt();
            deleteReceipt();
        }

        private static void AddItem()
        {

            try
            {
                Customer customer = new Customer
                {
                    ModelId = 1,
                    Type = "Xiaomi",
                    ShowPrice = 3000,
                };
                bool check = CustomerDAO.Instance.AddNewCustomer(customer);
                if (check)
                {
                    ModelBrand = "Xiaomi 2 ",
                    ModelName = "Xioami redmi 2",
                    ModelOrigin = "CHina",
                    ModelYearOfWarranty = 2,
                    TblPhones = new HashSet<Phone>()
                });

                if (AddModelSuccess)
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

        private static void addRecipt()
        {
            try
            {
                IReceiptRepository reRepo = new ReceiptRepository();
                bool success = reRepo.AddNewReceipt(new Receipt
                {
                    ReceiptDate = new DateTime(),
                    CustomerId = 1,
                });

                if (success)
                {
                    Console.WriteLine("Add recipt success");
                }
                else
                {
                    Console.WriteLine("Failed");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private static void updateRecipt()
        {
            try
            {
                IReceiptRepository reRepo = new ReceiptRepository();
                bool success = reRepo.UpdateReceipt(new Receipt
                {
                    ReceiptDate = new DateTime(2022,1,1),
                    CustomerId = 1,
                    ReceiptId = 1
                });

                if (success)
                {
                    Console.WriteLine("Update recipt success");
                }
                else
                {
                    Console.WriteLine("Failed");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private static void deleteReceipt()
        {
            try
            {
                IReceiptRepository reRepo = new ReceiptRepository();
                bool success = reRepo.RemoveReceipt(2);

                if (success)
                {
                    Console.WriteLine("Update recipt success");
                }
                else
                {
                    Console.WriteLine("Failed");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}