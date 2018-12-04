using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Travel.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Travel.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SampleDataController : Controller
    {
        private readonly TravelDbContext dbContext;
        private readonly ClaimsPrincipal user;

        public SampleDataController(TravelDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.user = httpContextAccessor.HttpContext.User;
        }

        [HttpGet]
        public IActionResult getUserData()
        {
            var userId = this.user.Claims.Single(c => c.Type == "id");
            var user = dbContext.Users.Single(c => c.Id.ToString() == userId.Value);

            return new OkObjectResult(new
            {
                user.Email,
                user.Password,
                user.Role,
            });

        }
    }
}
