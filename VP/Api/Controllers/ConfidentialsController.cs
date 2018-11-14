using ApiCore.Entities;
using ApiCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfidentialsController : Controller
    {
        private readonly IAWSAuthenticationService _aWSAuthenticationService;

        public ConfidentialsController(IAWSAuthenticationService aWSAuthenticationService)
        {
            _aWSAuthenticationService = aWSAuthenticationService;
        }

        [HttpGet("{email}")]
        public IActionResult Get(string email)
        {
            var awsAccessKeyId = "aws secret key id";
            var awsAccessKey = "aws secret key";
            var signInfo = new AwsSignInfo(email,
                                           awsAccessKeyId,
                                           awsAccessKey);

            var isAuthenticated =  _aWSAuthenticationService.IsAutenticated(signInfo);

            return Json(isAuthenticated);
        }
    }
}