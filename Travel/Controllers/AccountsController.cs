using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Travel.Data;
using Travel.Helpers;
using Travel.Models.Entites;
using Travel.Models.ViewModels;

namespace Travel.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
             private readonly TravelDbContext dbContext;
             private readonly UserManager<User> userManager;
             private readonly IMapper mapper;

             public AccountsController(UserManager<User> userManager, IMapper mapper, TravelDbContext dbContext)
             {
                 this.userManager = userManager;
                 this.mapper = mapper;
                 this.dbContext = dbContext;
             }

            // POST api/Accounts
            [HttpPost]
            public async Task<IActionResult> Post([FromBody]RegistrationVM model)
                {
                    if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var userIdentity = mapper.Map<User>(model);

                var result = await userManager.CreateAsync(userIdentity, model.Password);

                if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

                await dbContext.Clients.AddAsync(new Client { IdentityId = userIdentity.Id, Test = model.Test });
                await dbContext.SaveChangesAsync();

                return new OkObjectResult("Account created");
            }
    }
}