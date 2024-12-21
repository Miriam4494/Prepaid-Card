using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Data.Repositories
{
    public class CustomerRepository : IRepository<CustomerEntity>
    {
        readonly DataContext _dataContext;
        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<CustomerEntity> Get()
        {

            return _dataContext.customers.ToList();
        }
        public CustomerEntity GetById(int id)
        {
            if (_dataContext.customers == null || (_dataContext.customers.ToList().FindIndex(c => c.CustomerId == id) == -1))
                return null;
            return _dataContext.customers.Find( id);
        }
        #region especial function

        //פונקציה זו עדין אינה טובה צריך לטפל בה

        ////שליפת לקוחות לפי תאריך הצטרפות
        //public CustomerEntity GetCustomersByDateOfJoin(DateTime DateOfJoin)
        //{
        //    if (customers == null || (customers.FindIndex(c => c.CustomerId == id) == -1))
        //        return null;
        //    return customers.Find(c => c.CustomerId == id);
        //}
        #endregion

        public CustomerEntity Add(CustomerEntity customer)
        {
            if (_dataContext.customers.Find( customer.CustomerId) != null) return null;

            _dataContext.customers.Add(customer);
            try
            {
                _dataContext.SaveChanges();
                return customer;

            }
            catch (Exception ex)
            {
                return null;
            }
        }




        public CustomerEntity Update(int id, CustomerEntity customer)
        {
            if (_dataContext.customers == null || customer == null)
                return null;
            CustomerEntity c = _dataContext.customers.Find(id);
            if (c == null)
                return null;
            c.Adress = customer.Adress!=null?customer.Adress:c.Adress;
            c.FirstName = customer.FirstName!=null?customer.FirstName:c.FirstName;
            c.DateOfBirth = customer.DateOfBirth!=null?customer.DateOfBirth:c.DateOfBirth;
            c.DateOfJoin = customer.DateOfJoin!=null?customer.DateOfJoin:c.DateOfJoin;
            c.Email = customer.Email!=null ? customer.Email : c.Email;
            c.Phone = customer.Phone!=null?customer.Phone:c.Phone;
            c.LastName = customer.LastName != null ? customer.LastName : c.LastName;
            try
            {
                _dataContext.SaveChanges();
                return customer;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Delete(int id)
        {
            if (_dataContext.customers == null || (_dataContext.customers.Find(id) == null))
                return false;
            _dataContext.customers.Remove(_dataContext.customers.Find(id));
            try
            {
                _dataContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
