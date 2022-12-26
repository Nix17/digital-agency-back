using Application.Interfaces.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class OfferSupportRepo : GenericRepository<OfferSupportEntity>, IOfferSupportRepo
{
    public OfferSupportRepo(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
