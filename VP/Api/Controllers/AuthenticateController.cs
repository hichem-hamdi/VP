using ApiCore.Entities;
using ApiCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticateController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet("{email}/{password}")]
        public async Task<IActionResult> Get(string email, string password)
        {
            var loginInfo = new LoginInfo(email, password);
            var isAuthenticated = await _authenticationService.IsAuthenticated(loginInfo);

            return Json(isAuthenticated);
        }
    }
}