using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Core.Interfaces
{
    public interface IRepository<T>
    {
        public List<T> Get();
        public T? GetById(int id);
        public T Add(T t);
        public T Update(int id, T t);
        public bool Delete(int id);
    }
}
