using MobileSaleLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSaleLibrary.Repository.IRepository
{
    public interface IImportInfoRepository
    {
        IEnumerable<ImportInfo> GetImportInfoList();
        bool AddNewImportInfo(ImportInfo importInfo);
        bool RemoveImportInfo(int id, int phoneID);
        ImportInfo GetImportInfoByID(int id, int phoneID);
        bool UpdateImportInfo(ImportInfo importInfo);
    }
}
