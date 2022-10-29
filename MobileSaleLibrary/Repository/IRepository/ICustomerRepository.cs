using MobileSaleLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSaleLibrary.Repository.IRepository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomerList();
        bool AddNewCustomer(Customer customer);
        bool RemoveCustomer(int id);
        Customer GetCustomerByID(int id);
        bool UpdateCustomer(Customer customer);
    }
}
