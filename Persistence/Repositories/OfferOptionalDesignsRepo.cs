using Application.Interfaces.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class OfferOptionalDesignsRepo : GenericRepository<OfferOptionalDesignsEntity>, IOfferOptionalDesignsRepo
{
    public OfferOptionalDesignsRepo(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
