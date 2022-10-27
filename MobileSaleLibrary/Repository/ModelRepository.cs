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
    public class ModelRepository : IModelRepository
    {
        public IEnumerable<Model> GetModelsList() => ModelDAO.Instance.GetModelList();

        public Model GetModelByID(int modelID) => ModelDAO.Instance.GetModelByID(modelID);

        public bool AddNewModel(Model model) => ModelDAO.Instance.AddNewModel(model);
        public bool UpdateModel(Model model) => ModelDAO.Instance.UpdateModel(model);

        public bool DeleteModel(int modelID) => ModelDAO.Instance.DeleteModel(modelID);
    }
}
