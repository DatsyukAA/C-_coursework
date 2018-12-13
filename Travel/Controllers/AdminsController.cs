using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Travel.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Travel.Models.Entites.OrderModels;
using System;
using Travel.Models.ViewModels;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Travel.Controllers
{
    [Authorize(Policy = "admin_access")]
    [Route("api/[controller]/[action]")]
    public class AdminsController : Controller
    {
        private readonly TravelDbContext dbContext;
        private readonly ClaimsPrincipal user;

        public AdminsController(TravelDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.user = httpContextAccessor.HttpContext.User;
        }

        [HttpGet]
        public IActionResult getOrderData()
        {
            var orders = dbContext.Orders.Include(x => x.Client.User).Include(x =>x.Voucher).ToArray();
            ArrayList ordersvm = new ArrayList();
            foreach (Order order in orders)
            {
                ordersvm.Add(new OrdersVM
                {
                    Id = order.Id,
                    ClientId = order.Client.Id,
                    ClientName = order.Client.User.FirstName + " " + order.Client.User.LastName,
                    VoucherId = order.Voucher.Id,
                    Status = order.Status,
                    BeginDate = order.BeginDate.ToString().Substring(0, 10),
                    EndDate = order.EndDate.ToString().Substring(0, 10)
                });
            }
            return new OkObjectResult(ordersvm);
        }

        [HttpPut]
        public IActionResult updateOrderData([FromBody]OrdersVM order) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var client = dbContext.Clients.Include(x => x.User).SingleOrDefault(x => x.Id == order.ClientId);
            var local_order = new Order
            {
                Id = order.Id,
                Client = client,
                Status = order.Status,
                BeginDate = DateTime.ParseExact(order.BeginDate,"yyyy-MM-dd",null),
                EndDate = DateTime.ParseExact(order.EndDate, "yyyy-MM-dd", null),
                Voucher = dbContext.Vouchers.SingleOrDefault(x => x.Id == order.VoucherId)
            };
            dbContext.Orders.Update(local_order);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult deleteOrderData([FromBody]int order)
        {
            var local_order = dbContext.Orders.SingleOrDefault(c => c.Id == order);
            dbContext.Entry(local_order).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return Ok();
        }

    }
}
