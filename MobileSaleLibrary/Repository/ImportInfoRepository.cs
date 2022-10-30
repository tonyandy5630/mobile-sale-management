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
    public class ImportInfoRepository:IImportInfoRepository
    {
        public IEnumerable<ImportInfo> GetImportInfoList() => ImportInfoDAO.Instance.GetImportInfoList();
        public ImportInfo GetImportInfoByID(int id, int phoneID) => ImportInfoDAO.Instance.GetImportInfoByID( id, phoneID);
        public bool AddNewImportInfo(ImportInfo importInfo) => ImportInfoDAO.Instance.AddNewImportInfo(importInfo);
        public bool UpdateImportInfo(ImportInfo importInfo) => ImportInfoDAO.Instance.updateImportInfo(importInfo);
        public bool RemoveImportInfo(int id, int phoneID) => ImportInfoDAO.Instance.DeleteImportInfo( id, phoneID);
    }
}
