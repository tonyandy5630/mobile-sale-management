using MobileSaleLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSaleLibrary.DataAccess
{
    public class ImportDAO
    {
        private static ImportDAO instance = null;
        private static readonly object instanceLock = new object();

        public static ImportDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ImportDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Import> GetImportList()
        {
            var imports = new List<Import>();
            try
            {
                using var context = new SalePhoneMangementContext();
                imports = context.TblImports.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return imports;
        }

        public Import GetImportByID(int importID)
        {
            Import import = null;
            try
            {
                using var context = new SalePhoneMangementContext();
                import = context.TblImports.SingleOrDefault(c => c.ImportId == importID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return import;
        }

        public bool AddNewImport(Import import)
        {
            Import aImport;
            try
            {
                if (import.ImportId != 0)
                {
                    throw new Exception("Cannot insert ID when add item");
                    return false;
                }
                aImport = GetImportByID(import.ImportId);
                if (aImport == null)
                {
                    using var context = new SalePhoneMangementContext();
                    context.TblImports.Add(import);
                    return context.SaveChanges() == 1;
                }
                else
                {
                    throw new Exception("Import alredy exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool updateImport(Import import)
        {
            Import aImport = null;
            try
            {
                aImport = GetImportByID(import.ImportId);
                if (aImport != null)
                {
                    using var context = new SalePhoneMangementContext();
                    context.TblImports.Update(import);
                    return context.SaveChanges() == 1;
                }
                else
                {
                    throw new Exception("Import not exist ");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteImport(int importID)
        {
            Import dImport = GetImportByID(importID);
            try
            {
                if (dImport != null)
                {
                    using var context = new SalePhoneMangementContext();
                    context.Remove(dImport);
                    return context.SaveChanges() == 1;
                }
                else
                {
                    throw new Exception("Import not exist !!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
