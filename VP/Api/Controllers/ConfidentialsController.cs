using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCore.Interfaces;
using Microsoft.AspNetCore.Http;
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

            var isAuthenticated =  _aWSAuthenticationService.IsAutenticated(email, awsAccessKeyId, awsAccessKey);

            return Json(isAuthenticated);
        }
    }
}