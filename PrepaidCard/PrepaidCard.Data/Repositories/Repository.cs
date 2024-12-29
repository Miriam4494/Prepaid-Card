using Microsoft.EntityFrameworkCore;
using PrepaidCard.Core.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;
    
        public Repository(DataContext dataContext)
        {
            _dbSet = dataContext.Set<T>();
        }
        public List<T> Get()
        {
            return _dbSet.ToList();
        }
        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public T Add(T t)
        {
            _dbSet.Add(t);
            
            return t;
        }
        public T Update(int id, T updatedEntity)
        {
            var existingEntity = _dbSet.Find(id);
            if (existingEntity == null)
            {
                return null;
            }
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                      .Where(prop => prop.Name != "Id");

            foreach (var property in properties)
            {
                var updatedValue = property.GetValue(updatedEntity);

                if (updatedValue != null)
                {
                    property.SetValue(existingEntity, updatedValue);
                }
            }
            return existingEntity;
        }
        public bool Delete(int id)
        {
            T find = _dbSet.Find(id);
            if (find != null)
            {
                _dbSet.Remove(find);
             
                return true;
            }
            return false;
        }
    }

    }


    
