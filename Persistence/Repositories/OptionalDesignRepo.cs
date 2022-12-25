﻿using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class OptionalDesignRepo : GenericRepository<OptionalDesignEntity>, IOptionalDesignRepo
{
    public OptionalDesignRepo(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
