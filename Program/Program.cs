// See husing System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MobileSaleLibrary.DataAccess;
using MobileSaleLibrary.Models;
using MobileSaleLibrary.Repository;
using MobileSaleLibrary.Repository.IRepository;

namespace Program // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            AddPhone();

        }

        private static void AddPhone()
        {
            
            try
            {
                PhoneRepository phoneRepo = new PhoneRepository();
                ModelRepository modelRepo = new ModelRepository();
                //Model Model = 
                var Phone = new Phone
                {
                    ModelId=1,
                    Type= "Xiaomi",
                    ShowPrice=3000,
                };
                bool AddModelSuccess = modelRepo.AddNewModel(new Model
                {
                    ModelBrand = "Xiaomi 2 ",
                    ModelName = "Xioami redmi 2",
                    ModelOrigin = "CHina",
                    ModelYearOfWarranty = 2,
                    TblPhones = new HashSet<Phone>()
                }) ; 

                if(AddModelSuccess)
                {
                    Console.WriteLine("Created model successfully");
                }
                else
                {
                    Console.WriteLine("Created Model fail");
                }

                bool AddPhoneSuccess = phoneRepo.AddNewPhone(Phone);
                if (AddPhoneSuccess)
                {
                    Console.WriteLine("Successfull");
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }
    }
}