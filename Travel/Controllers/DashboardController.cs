using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using Travel.Auth;
using Travel.Data;

namespace Travel.Controllers
{
    [Authorize(Policy = "user_access")]
    [Route("api/[controller]/[Action]")]
    public class DashboardController : Controller
    {
        private readonly UserManager userManager;
        private readonly ClaimsPrincipal caller;
        private readonly TravelDbContext dbContext;

        public DashboardController(TravelDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            userManager = new UserManager(dbContext);
            caller = httpContextAccessor.HttpContext.User;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult Home()
        {
            var userId = Convert.ToInt32(caller.Claims.Single(c => c.Type == "id").Value);
            var customer = dbContext.Clients.Single(c => c.Id == userId);
            return new OkObjectResult(new
            {
                customer.Id,
                customer.Email,
                customer.Password
            });
        }
    }
}