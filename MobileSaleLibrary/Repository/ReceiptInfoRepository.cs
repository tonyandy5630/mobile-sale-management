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
    public class ReceiptInfoRepository:IReceiptInfoRepository
    {
        public IEnumerable<ReceiptInfo> GetReceiptInfoList() => ReceiptInfoDAO.Instance.getRecipeInfoList();
        public bool CreateReceiptInfo(ReceiptInfo recInfo) => ReceiptInfoDAO.Instance.CreateNewReceiptInfo(recInfo);
    }
}
