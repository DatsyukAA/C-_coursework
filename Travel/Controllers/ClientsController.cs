using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Travel.Data;
using Travel.Models.Entites.OrderModels;
using Travel.Models.ViewModels;

namespace Travel.Controllers
{
    [Authorize(Policy = "client_access")]
    [Route("api/[controller]/[action]")]
    public class ClientsController : Controller
    {
        private readonly TravelDbContext dbContext;
        private readonly ClaimsPrincipal user;

        public ClientsController(TravelDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.user = httpContextAccessor.HttpContext.User;
        }

        [HttpGet]
        public IActionResult getToursData()
        {
            var tours = dbContext.Tours.Include(x => x.Counry).Include(x => x.Hotel).Include(x => x.Resort).ToArray();
            ArrayList toursvm = new ArrayList();
            foreach (Tour tour in tours)
            {
                toursvm.Add(new ToursVM
                {
                    Id = tour.Id,
                    CountryId = tour.Counry.Id,
                    CountryName = tour.Counry.CountryName,
                    HotelId = tour.Hotel.Id,
                    HotelName = tour.Hotel.HotelName,
                    ResortId = tour.Resort.Id,
                    ResortName = tour.Resort.ResortName,
                    Status = tour.Status
                });
            }
            return new OkObjectResult(toursvm);
        }

        [HttpPost]
        public IActionResult getSearchResult([FromBody]int resortId)
        {
            List<Voucher> vouchers = new List<Voucher>();

            vouchers = dbContext.Vouchers.Include(x => x.Tour).Include(x => x.Tour.Resort).Where(x => x.InCurrentList == true && x.Tour.Resort.Id == resortId).ToList();

            ArrayList vouchersvm = new ArrayList();
            foreach (Voucher voucher in vouchers)
            {
                vouchersvm.Add(new VouchersVM
                {
                    Id = voucher.Id,
                    TourId = voucher.Tour.Id,
                    Status = voucher.Status,
                    BeginDate = voucher.EnableFrom.ToShortDateString(),
                    EndDate = voucher.EnableTo.ToShortDateString(),
                    InCurrentList = voucher.InCurrentList,
                    Cost = voucher.Cost,
                    Discount = voucher.Discount
                });
            }
            return new OkObjectResult(vouchersvm);
        }

        [HttpPost]
        public IActionResult makeAnOrder([FromBody]OrdersVM order)
        {
            var local_voucher = dbContext.Vouchers.Include(c => c.Tour).SingleOrDefault(x => x.Id == order.VoucherId);
            var userId = user.Claims.SingleOrDefault(c => c.Type == "id").Value;
            var local_user = dbContext.Clients.Include(c => c.User).SingleOrDefault(x => x.UserId.ToString() == userId);
            if ( local_user.Cash >= (local_voucher.Cost - local_voucher.Cost * local_voucher.Discount/100))
            {
            var local_order = new Order
            {
                ClientId = local_user.Id,
                VoucherId = local_voucher.Id,
                Status = 0,
                BeginDate = DateTime.ParseExact(order.BeginDate, "dd.MM.yyyy", null),
                EndDate = DateTime.ParseExact(order.EndDate, "dd.MM.yyyy", null)
            };
            dbContext.Orders.Add(local_order);
            local_user.TravelHistory.Add(local_order);
            local_user.Cash = local_user.Cash - local_voucher.Cost;
            dbContext.Clients.Update(local_user);
            dbContext.SaveChanges();
            return new OkObjectResult("order accepted");
            }
            return new BadRequestObjectResult("need more cash");
        }
    }
}