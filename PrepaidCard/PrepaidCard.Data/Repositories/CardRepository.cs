using Microsoft.EntityFrameworkCore;
using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PrepaidCard.Data.Repositories.CardRepository;

namespace PrepaidCard.Data.Repositories
{

    public class CardRepository:Repository<CardEntity>,ICardRepository
    {
            public CardRepository(DataContext dataContext): base(dataContext)
            {
              
            }
            public List<CardEntity> GetFull()
            {
                return _dbSet.Include(c => c.Purchase).ToList();
            }

        }
}
