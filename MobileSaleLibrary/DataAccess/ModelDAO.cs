using MobileSaleLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSaleLibrary.DataAccess
{
    public class ModelDAO
    {
        // do not touch Id
        private static ModelDAO instance = null;
        private static readonly object instanceLock = new object();

        public static ModelDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ModelDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Model> GetModelList()
        {
            var models = new List<Model>();
            try
            {
                using var context = new SalePhoneMangementContext();
                models = context.TblModels.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return models;
        }

        public Model GetModelByID(int modelID)
        {
            Model model = null;
            try
            {
                using var context = new SalePhoneMangementContext();
                model = context.TblModels.SingleOrDefault(model => model.ModelId == modelID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return model;
        }

        public bool AddNewModel(Model model)
        {
            Model aModel;
            try
            {
                aModel = GetModelByID(model.ModelId);
                if (aModel == null)
                {
                    using var context = new SalePhoneMangementContext();    
                    context.TblModels.Add(model);
                    return context.SaveChanges() == 1;
                }
                else
                {
                    throw new Exception("Model alredy exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateModel(Model model)
        {
            Model aModel = null;
            try
            {
                model = GetModelByID(model.ModelId);
                if (aModel == null)
                {
                    using var context = new SalePhoneMangementContext();
                    context.TblModels.Update(model);
                    return context.SaveChanges() == 1;
                }
                else
                {
                    throw new Exception("Model not exist ");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteModel(int modelID)
        {
            Model dModel = GetModelByID(modelID);
            try
            {
                if (dModel != null)
                {
                    using var context = new SalePhoneMangementContext();
                    context.Remove(dModel);
                    return context.SaveChanges() == 1;
                }
                else
                {
                    throw new Exception("Model not exist !!");
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
