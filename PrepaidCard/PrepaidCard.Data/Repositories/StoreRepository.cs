using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Data.Repositories
{
    public class StoreRepository:Repository<StoreEntity>, IStoreRepository
    {

            public StoreRepository(DataContext dataContext) : base(dataContext)
            {

            }
            public List<StoreEntity> GetFull()
            {
                return _dbSet.ToList();
            }

        }
}
