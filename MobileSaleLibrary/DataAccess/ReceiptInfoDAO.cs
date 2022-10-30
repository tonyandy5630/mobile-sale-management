using MobileSaleLibrary.Models;
using MobileSaleLibrary.Repository;
using MobileSaleLibrary.Repository.IRepository;
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

        public IEnumerable<ReceiptInfo> GetReciptInfoByReceiptID(int receiptID)
        {
            var reciptInfos = new List<ReceiptInfo>();
            try
            {
                using var context = new SalePhoneMangementContext();
                reciptInfos = context.TblReceiptInfos.Where(r => r.ReceiptId == receiptID).ToList();
                return reciptInfos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public bool DeleteReceiptInfoByReceiptIDAndPhoneID(int receiptID, int phoneID)
        {
            IReceiptRepository recRepo = new ReceiptRepository();
            Receipt dRec = null;
            try
            {
                dRec = recRepo.GetReceiptByID(receiptID);
                if (dRec != null)
                {
                    using var context = new SalePhoneMangementContext();
                    ReceiptInfo deleteReceipt = context.TblReceiptInfos.SingleOrDefault(reci => reci.ReceiptId == dRec.ReceiptId && reci.PhoneId == phoneID);
                    if(deleteReceipt != null)
                    {
                        context.TblReceiptInfos.Remove(deleteReceipt);
                    }
                    else
                    {
                        throw new Exception("Not exist recipt info");
                    }
                    return context.SaveChanges() == 1;
                }
                else
                {
                    throw new Exception("Reciept not existed");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool CreateNewReceiptInfo(ReceiptInfo recInf)
        {
            try
            {
                using var context = new SalePhoneMangementContext();
                context.TblReceiptInfos.Add(recInf);
                return context.SaveChanges() == 1;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool UpdateReceiptInfo(ReceiptInfo updateReceipt)
        {
            IReceiptRepository recRepo = new ReceiptRepository();
            Receipt uRec = null;
            try
            {
                uRec = recRepo.GetReceiptByID(updateReceipt.ReceiptId);
                if (uRec != null)
                {
                    using var context = new SalePhoneMangementContext();
                    context.TblReceiptInfos.Update(updateReceipt);
                    return context.SaveChanges() == 1;
                }
                else
                {
                    throw new Exception("Receipt not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
