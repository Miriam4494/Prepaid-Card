﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Data.Repositories
{
    public class CustomerRepository : Repository<CustomerEntity>,ICustomerRepository
    {


        public CustomerRepository(DataContext dataContext) : base(dataContext)
        {

        }
        public async Task<IEnumerable<CustomerEntity>> GetFullAsync()
        {
            return await _dbSet.Include(c => c.Cards).ToListAsync();
        }
       


    }
}
