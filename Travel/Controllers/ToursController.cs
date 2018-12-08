using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;
using System.Security.Claims;
using Travel.Data;
using Travel.Models.Entites.OrderModels;

namespace Travel.Controllers
{
   /* [Route("api/[controller]/[action]")]
    public class ToursController : Controller
    {
        private readonly TravelDbContext dbContext;
        private readonly ClaimsPrincipal user;

        public ToursController(TravelDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.user = httpContextAccessor.HttpContext.User;
        }

        [HttpGet]
        public IActionResult getTourData(ToursVM tourvm)
        {
            var tours = dbContext.Tours.Include(x => x.Counry).Include(x => x.Resort).Include(x => x.Hotel).Where(x => x.Counry == tourvm.country && x.Hotel == tourvm.hotel && x.Resort == tourvm.resort).ToArray();
            ArrayList availabletours = new ArrayList();
            foreach (Tour tour in tours)
            {
                availabletours.Add(new ToursVM);
            }
            return new OkObjectResult(availabletours);
        }
    }*/
}