using MobileSaleLibrary.DataAccess;
using MobileSaleLibrary.Models;
using MobileSaleLibrary.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSaleLibrary.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        public IEnumerable<Customer> GetCustomerList() => CustomerDAO.Instance.GetCustomerList();
        public Customer GetCustomerByID(int id) => CustomerDAO.Instance.GetCustomerByID(id);
        public bool AddNewCustomer(Customer customer) => CustomerDAO.Instance.AddNewCustomer(customer);
        public bool UpdateCustomer(Customer customer) => CustomerDAO.Instance.updateCustomer(customer);
        public bool RemoveCustomer(int id) => CustomerDAO.Instance.DeleteCustomer(id);
    }
}
