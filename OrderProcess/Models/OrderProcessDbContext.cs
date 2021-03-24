using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcess.Models
{
    public class OrderProcessDbContext : DbContext
    {
        public OrderProcessDbContext(DbContextOptions<OrderProcessDbContext> options)
    : base(options)
        {
        }
        public DbSet<OrderEntity> ProcessOrder { get; set; }
    }
}
