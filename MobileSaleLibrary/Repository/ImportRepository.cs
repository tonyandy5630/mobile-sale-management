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
    public class ImportRepository:IImportInfoRepository
    {
        public IEnumerable<ImportInfo> GetImportInfoList() => ImportInfoDAO.Instance.GetImportInfoList();
        public ImportInfo GetImportInfoByID(int id) => ImportInfoDAO.Instance.GetImportInfoByID(id);
        public bool AddNewImportInfo(ImportInfo importInfo) => ImportInfoDAO.Instance.AddNewImportInfo(importInfo);
        public bool UpdateImportInfo(ImportInfo importInfo) => ImportInfoDAO.Instance.updateImportInfo(importInfo);
        public bool RemoveImportInfo(int id) => ImportInfoDAO.Instance.DeleteImportInfo(id);
    }
}
