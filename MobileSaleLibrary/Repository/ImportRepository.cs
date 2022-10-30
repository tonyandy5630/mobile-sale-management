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
    public class ImportRepository:IImportRepository
    {
        public IEnumerable<Import> GetImportList() => ImportDAO.Instance.GetImportList();
        public Import GetImportByID(int id) => ImportDAO.Instance.GetImportByID(id);
        public bool AddNewImport(Import import) => ImportDAO.Instance.AddNewImport(import);
        public bool UpdateImport(Import import) => ImportDAO.Instance.updateImport(import);
        public bool RemoveImport(int id) => ImportDAO.Instance.DeleteImport(id);
        
    }
}
