using Common.Kafka.Consumer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcess.Models
{
    public class OrderEntityCreatedHandler : IKafkaHandler<string, OrderEntity>
    {
        private readonly OrderProcessDbContext _dbContext;

        public OrderEntityCreatedHandler(OrderProcessDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task HandleAsync(string key, OrderEntity value)
        {

            var order = new OrderEntity
            {
               
                UserName = value.UserName,
                UserAddress = value.UserAddress,
                UserEmail = value.UserEmail,
            };

            _dbContext.ProcessOrder.Add(order);

          var x=  await _dbContext.SaveChangesAsync();
        }
    }
}
