using MobileSaleLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSaleLibrary.Repository.IRepository
{
    public interface IReceiptRepository
    {
        IEnumerable<Receipt> GetReceiptList();
        bool AddNewReceipt(Receipt receipt);
        bool RemoveReceipt(int  id);
        Receipt GetReceiptByID(int id);
        bool UpdateReceipt(Receipt receipt);
    }
}
