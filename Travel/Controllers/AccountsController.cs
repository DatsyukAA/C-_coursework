using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Travel.Data;
using Travel.Models.Entites;
using Travel.Models.ViewModels;

namespace Travel.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
             private readonly TravelDbContext dbContext;

             public AccountsController(TravelDbContext dbContext)
             {
                 this.dbContext = dbContext;
             }

        // POST api/Accounts
        [HttpPost]
        public ActionResult Post([FromBody]RegistrationVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!(dbContext.Clients.Where(x => x.Email == model.Email).Count() > 0))
            {

                dbContext.Clients.AddAsync(new Client
                    {
                        Email = model.Email,
                        Password = model.Password,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Test = model.Test
                    });
               dbContext.SaveChangesAsync();

                return new OkObjectResult("Account created");
            }
            return new BadRequestObjectResult("Account not created, email already exisits!");
        }
    }
}