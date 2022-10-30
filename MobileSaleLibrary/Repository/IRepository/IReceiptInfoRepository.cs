using MobileSaleLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSaleLibrary.Repository.IRepository
{
    public interface IReceiptInfoRepository
    {
        IEnumerable<ReceiptInfo> GetReceiptInfoList();
        IEnumerable<ReceiptInfo> GetReceiptInfoListByRecieptID(int id);
        bool DeleteReceiptInfoByReceiptIDAndPhoneID(int receiptId, int phoneId);

        bool UpdateReceiptInfo(ReceiptInfo receiptInfo);

        bool CreateReceiptInfo(ReceiptInfo recInfo);

        
    }
}
