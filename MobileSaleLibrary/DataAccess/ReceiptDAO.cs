using MobileSaleLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSaleLibrary.DataAccess
{
    public class ReceiptDAO
    {
        // do not touch Id
        private static ReceiptDAO instance = null;
        private static readonly object instanceLock = new object();

        public static ReceiptDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ReceiptDAO();
                    }
                    return instance;
                }
            }
        }


        public IEnumerable<Receipt> getRecipeList()
        {
            var receipts = new List<Receipt>();
            try
            {
                using var context = new SalePhoneMangementContext();
                receipts = context.TblReceipts.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return receipts;
        }

        public Receipt GetReceiptByID(int  id)
        {
            Receipt receipt = null;
            try
            {
                using var context = new SalePhoneMangementContext();
                receipt = context.TblReceipts.SingleOrDefault(recipt => recipt.ReceiptId  == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return receipt;
        }

        public bool AddNewRecipt(Receipt rec)
        {
            try
            {
                Receipt addRe = GetReceiptByID(rec.ReceiptId);
                if(addRe == null)
                {
                    using var context = new SalePhoneMangementContext();
                    context.TblReceipts.Add(rec);
                    return context.SaveChanges() == 1;
                }
                else
                {
                    throw new Exception("Receipt is existed");
                }

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return false;
        }

        public bool RemoveRecipt(int recId)
        {
            try
            {
                Receipt rRec = GetReceiptByID(recId);
                if(rRec != null)
                {
                    using var context = new SalePhoneMangementContext();
                    context.TblReceipts.Remove(rRec);
                    return context.SaveChanges() == 1;
                }
                else
                {
                    throw new Exception("Recipt is not existed");
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool UpdateReceipt(Receipt rec)
        {
            try
            {
                Receipt URec = GetReceiptByID(rec.ReceiptId);
                if(URec != null)
                {
                    using var context = new SalePhoneMangementContext();
                    context.TblReceipts.Update(rec);
                    return context.SaveChanges() == 1;
                }
                else
                {
                    throw new Exception("Recipt is not existed");
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
