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

        //שליפת רשימת לקוחות
        public List<CustomerEntity> Get()
        {

            return _dataContext.customers;
        }
        //שליפת לקוח לפי מזהה
        public CustomerEntity GetById(int id)
        {
            if (_dataContext.customers == null || (_dataContext.customers.FindIndex(c => c.CustomerId == id) == -1))
                return null;
            return _dataContext.customers.Find(c => c.CustomerId == id);
        }
        #region פונקציות מיוחדות

        //פונקציה זו עדין אינה טובה צריך לטפל בה

        ////שליפת לקוחות לפי תאריך הצטרפות
        //public CustomerEntity GetCustomersByDateOfJoin(DateTime DateOfJoin)
        //{
        //    if (customers == null || (customers.FindIndex(c => c.CustomerId == id) == -1))
        //        return null;
        //    return customers.Find(c => c.CustomerId == id);
        //}
        #endregion

        //הוספת לקוח
        public bool Add(CustomerEntity customer)
        {
            if (_dataContext.customers == null)
                _dataContext.customers = new List<CustomerEntity>();
            if (_dataContext.customers.Find(c => c.CustomerId == customer.CustomerId) != null) return false;

            _dataContext.customers.Add(customer);
            return _dataContext.Save(_dataContext.customers, "Data/Customers.csv");
        }
        //עדכון לקוח
        public bool Update(int id, CustomerEntity customer)
        {
            if (_dataContext.customers == null || (_dataContext.customers.Find(c => c.CustomerId == id) == null))
                return false;
            int index = _dataContext.customers.FindIndex(c => c.CustomerId == id);
            _dataContext.customers[index].Adress = customer.Adress;
            _dataContext.customers[index].FirstName = customer.FirstName;
            _dataContext.customers[index].DateOfBirth = customer.DateOfBirth;
            _dataContext.customers[index].DateOfJoin = customer.DateOfJoin;
            _dataContext.customers[index].Email = customer.Email;
            _dataContext.customers[index].Phone = customer.Phone;
            _dataContext.customers[index].LastName = customer.LastName;
            return _dataContext.Save(_dataContext.customers, "Data/Customers.csv");

        }
        //מחיקת לקוח
        public bool Delete(int id)
        {
            if (_dataContext.customers == null || !(_dataContext.customers.Exists(c => c.CustomerId == id)))
                return false;
            _dataContext.customers.Remove(_dataContext.customers.Find(c => c.CustomerId == id));
            return _dataContext.Save(_dataContext.customers, "Data/Customers.csv"); ;
        }
    }
}
