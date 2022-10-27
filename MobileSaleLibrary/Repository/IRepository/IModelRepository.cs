using MobileSaleLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSaleLibrary.Repository.IRepository
{
    public  interface IModelRepository
    {
        IEnumerable<Model> GetModelsList();
        Model GetModelByID(int modelID);
        bool UpdateModel(Model model);
        bool AddNewModel(Model model);
        bool DeleteModel(int modelID);
    }
}
