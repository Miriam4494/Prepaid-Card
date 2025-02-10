using PrepaidCard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Core.Interfaces.IRepositories
{
   
    public interface IPurchaseRepository : IRepository<PurchaseEntity>
    {
        public Task<IEnumerable<PurchaseEntity>> GetFullAsync();
    }
}
