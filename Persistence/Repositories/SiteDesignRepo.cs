using Application.Interfaces.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class SiteDesignRepo : GenericRepository<SiteDesignEntity>, ISiteDesignRepo
{
    public SiteDesignRepo(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
