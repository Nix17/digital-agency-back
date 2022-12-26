using Application.Interfaces.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class OrderRepo : GenericRepository<OrderEntity>, IOrderRepo
{
    public OrderRepo(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
