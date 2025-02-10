using Microsoft.EntityFrameworkCore;
using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Data.Repositories
{
    public class PurchaseCenterRepository:Repository<PurchaseCenterEntity>,IPurchaseCenterRepository
    {


        public PurchaseCenterRepository(DataContext dataContext) : base(dataContext)
        {

        }
        public async Task<IEnumerable<PurchaseCenterEntity>> GetFullAsync()
        {
            return await _dbSet.Include(p => p.Purchase).ToListAsync();
        }
     

    }
}
