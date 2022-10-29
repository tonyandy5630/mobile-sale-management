using MobileSaleLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSaleLibrary.DataAccess
{
    public class ImportInfoDAO
    {
        private static ImportInfoDAO instance = null;
        private static readonly object instanceLock = new object();

        public static ImportInfoDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ImportInfoDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<ImportInfo> GetImportInfoList()
        {
            var importInfos = new List<ImportInfo>();
            try
            {
                using var context = new SalePhoneMangementContext();
                importInfos = context.TblImportInfos.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return importInfos;
        }

        public ImportInfo GetImportInfoByID(int importInfoID, int phoneID)
        {
            ImportInfo importInfo = null;
            try
            {
                using var context = new SalePhoneMangementContext();
                importInfo = context.TblImportInfos.SingleOrDefault(c => c.ImportId == importInfoID && c.PhoneId == phoneID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return importInfo;
        }

        public bool AddNewImportInfo(ImportInfo importInfo)
        {
            ImportInfo aImportInfo;
            try
            {
               
                aImportInfo = GetImportInfoByID(importInfo.ImportId, importInfo.PhoneId);
                if (aImportInfo == null)
                {
                    using var context = new SalePhoneMangementContext();
                    context.TblImportInfos.Add(importInfo);
                    return context.SaveChanges() == 1;
                }
                else
                {
                    throw new Exception("ImportInfo alredy exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool updateImportInfo(ImportInfo importInfo)
        {
            ImportInfo aImportInfo = null;
            try
            {
                aImportInfo = GetImportInfoByID(importInfo.ImportId, importInfo.PhoneId);
                if (aImportInfo != null)
                {
                    using var context = new SalePhoneMangementContext();
                    context.TblImportInfos.Update(importInfo);
                    return context.SaveChanges() == 1;
                }
                else
                {
                    throw new Exception("ImportInfo not exist ");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteImportInfo(int importInfoID, int phoneID)
        {
            ImportInfo dImportInfo = GetImportInfoByID(importInfoID, phoneID);
            try
            {
                if (dImportInfo != null)
                {
                    using var context = new SalePhoneMangementContext();
                    context.Remove(dImportInfo);
                    return context.SaveChanges() == 1;
                }
                else
                {
                    throw new Exception("ImportInfo not exist !!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
