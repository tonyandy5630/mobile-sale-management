using MobileSaleLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSaleLibrary.Repository.IRepository
{
    public interface IPhoneRepository
    {
        IEnumerable<Phone> GetPhones();
        Phone GetPhoneByID(int phoneID);
        bool AddNewPhone(Phone phone);
        bool UpdatePhone(Phone phone);
        bool DeletePhone(int phoneID);
    }
}
