using MobileSaleLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSaleLibrary.DataAccess
{
    public class ReceiptInfoDAO
    {
        private static ReceiptInfoDAO instance = null;
        private static readonly object instanceLock = new object();

        public static ReceiptInfoDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ReceiptInfoDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<ReceiptInfo> getRecipeInfoList()
        {
            var receiptInfos = new List<ReceiptInfo>();
            try
            {
                using var context = new SalePhoneMangementContext();
                receiptInfos = context.TblReceiptInfos.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return receiptInfos;
        }

        public bool CreateNewReceiptInfo(ReceiptInfo recInf)
        {
            try
            {
                using var context = new SalePhoneMangementContext();
                context.TblReceiptInfos.Add(recInf);
                return context.SaveChanges() == 1;
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
