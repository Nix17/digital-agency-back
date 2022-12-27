using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class OfferRepo : GenericRepository<OfferEntity>, IOfferRepo
{
    public OfferRepo(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<int> GetMaxOfferNumber()
    {
        return await _context.Offers.MaxAsync(p => p.OfferNumber);
    }
}
