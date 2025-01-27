using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Data.Repositories
{
    public class PurchaseRepository:Repository<PurchaseEntity>,IPurchaseRepository
    {


        public PurchaseRepository(DataContext dataContext) : base(dataContext)
        {

        }
        public List<PurchaseEntity> GetFull()
        {
            return _dbSet.ToList();
        }

    }
}
