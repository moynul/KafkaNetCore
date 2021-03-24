using Common.Kafka;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IKafkaMessageBus<string, OrderEntity> _bus;
        private readonly ApplicationDbContext _dbContext;

        public OrderController(IKafkaMessageBus<string, OrderEntity> bus, ApplicationDbContext dbContext)
        {
            _bus = bus;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult> UserOrder([FromBody] OrderEntity command)
        {
            try
            {

                if (await _dbContext.CustomerOrder.AsNoTracking().AnyAsync(s => s.UserEmail == command.UserEmail))
                    throw new ApplicationException("Email is already exist.");

                var user = new OrderEntity
                {
                    Id = command.Id,
                    UserName = command.UserName,
                    UserAddress = command.UserAddress,
                    UserEmail = command.UserEmail,
                };

                _dbContext.CustomerOrder.Add(user);

                await _dbContext.SaveChangesAsync();

                await _bus.PublishAsync(command.UserEmail, user);

                return Ok("User Order Produce");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
