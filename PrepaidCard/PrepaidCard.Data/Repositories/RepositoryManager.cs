using PrepaidCard.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        DataContext _dataContext;
        public RepositoryManager(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void save()
        {
            _dataContext.SaveChanges();
        }
    }
}
