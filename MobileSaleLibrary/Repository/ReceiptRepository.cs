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
    public class ReceiptRepository : IReceiptRepository
    {
        public IEnumerable<Receipt> GetReceiptList() => ReceiptDAO.Instance.getRecipeList();
        public Receipt GetReceiptByID(int id) => ReceiptDAO.Instance.GetReceiptByID(id);
        public bool AddNewReceipt(Receipt rec) => ReceiptDAO.Instance.AddNewRecipt(rec);
        public bool UpdateReceipt(Receipt rec) => ReceiptDAO.Instance.UpdateReceipt(rec);
        public bool RemoveReceipt(int id) => ReceiptDAO.Instance.RemoveRecipt(id);
    }
}
