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
    public class PhoneRepository:IPhoneRepository
    {
        public IEnumerable<Phone> GetPhones() => PhoneDAO.Instance.GetPhoneList();
        public Phone GetPhoneByID(int phoneID) => PhoneDAO.Instance.GetPhoneByID(phoneID);

        public bool AddNewPhone(Phone phone) => PhoneDAO.Instance.AddNewPhone(phone);

        public bool UpdatePhone(Phone phone) => PhoneDAO.Instance.UpdatePhone(phone);

        public bool DeletePhone(int phoneID) => PhoneDAO.Instance.RemovePhone(phoneID);
    }
}
