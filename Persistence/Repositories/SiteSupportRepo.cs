using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class SiteSupportRepo : GenericRepository<SiteSupportEntity>, ISiteSupportRepo
{
    public SiteSupportRepo(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
