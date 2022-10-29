using MobileSaleLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSaleLibrary.Repository.IRepository
{
    public interface IImportRepository
    {
        IEnumerable<Import> GetImportList();
        bool AddNewImport(Import import);
        bool RemoveImport(int id);
        Import GetImportByID(int id);
        bool UpdateImport(Import import);
    }
}
