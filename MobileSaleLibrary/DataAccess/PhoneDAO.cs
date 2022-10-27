using MobileSaleLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSaleLibrary.DataAccess
{
    public class PhoneDAO
    {
        // do not touch Id
        private static PhoneDAO instance = null;
        private static readonly object instanceLock = new object();

        public static PhoneDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if(instance == null)
                    {
                        instance = new PhoneDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Phone> GetPhoneList()
        {
            var phones = new List<Phone>();
            try
            {
                using var context = new SalePhoneMangementContext();
                phones = context.TblPhones.ToList();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return phones;
        }

        public Phone GetPhoneByID(int phoneID)
        {
            Phone phone = null;
            try
            {
                using var context = new SalePhoneMangementContext();
                phone = context.TblPhones.SingleOrDefault(phone => phone.PhoneId == phoneID);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return phone;
        }

        public bool AddNewPhone(Phone phone)
        {
            try
            {
                Phone uPhone = GetPhoneByID(phone.PhoneId);
                if(uPhone == null)
                {
                    using var context = new SalePhoneMangementContext();
                    context.TblPhones.Add(phone);
                    // save change successfully
                    return  context.SaveChanges() == 1;
                }
                else
                {
                    throw new Exception("Phone is existed!");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdatePhone(Phone phone)
        {
            try
            {
                Phone uPhone = GetPhoneByID(phone.PhoneId);
                if(uPhone != null)
                {
                    using var context = new SalePhoneMangementContext();
                    context.TblPhones.Update(phone);
                    return context.SaveChanges() == 1;
                }
                else
                {
                    throw new Exception("Phone not existed");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool RemovePhone(int phoneID)
        {
            try
            {
                Phone phone = GetPhoneByID(phoneID);
                if(phone != null )
                {
                    using var context = new SalePhoneMangementContext();
                    context.TblPhones.Remove(phone);
                    return context.SaveChanges() == 1;
                }
                else
                {
                    throw new Exception("Phone not exist !");
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
