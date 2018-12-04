using Microsoft.AspNetCore.Mvc;
using Travel.Auth;
using Travel.Models.ViewModels;
using Newtonsoft.Json;
using Travel.Models.Entites;
using System.Security.Claims;
using Travel.Data;
using Microsoft.Extensions.Options;

namespace Travel.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly JwtFactory jwtFactory;
        private readonly JwtIssuerOptions jwtOptions;
        private readonly TravelDbContext dbContext;
        private readonly UserManager userManager;

        public AuthController(TravelDbContext dbContext, IOptions<JwtIssuerOptions>jwtOptions, JwtFactory jwtFactory)
        {
            this.dbContext = dbContext;
            userManager = new UserManager(dbContext);
            this.jwtFactory = jwtFactory;
            this.jwtOptions = jwtOptions.Value;
        }

        [HttpPost("login")]
        public ActionResult Post([FromBody]CredentialsVM credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identity = GetClaimsIdentity(credentials.Email,credentials.Password);//Add Identity

            if (identity == null)
            {
                return BadRequest("Invalid username or Password");
            }

            var jwt = JwtFactory.GenerateJwt(identity, jwtFactory, credentials.Email, jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
            return new OkObjectResult(jwt);
        }

        private ClaimsIdentity GetClaimsIdentity(string userName, string Password)
        {
            User userToVerify = userManager.getClientByName(userName);
            if (userToVerify == null) return new ClaimsIdentity();
            if (userManager.checkPassword(userToVerify,Password))
            {
                return jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id, userToVerify.Role);
            }

            return new ClaimsIdentity();
        }
    }
}