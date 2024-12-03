using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Core.Interfaces
{
    public interface IService<T>
    {
        public List<T> Get();
        public T GetById(int id);
        public bool Add(T t);
        public bool Update(int id, T t);
        public bool Delete(int id);
    }
}
