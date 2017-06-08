using Microsoft.AspNetCore.Mvc;
using SampleManager.Core.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserQueryService _userQueryService;

        public UserController(IUserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var results = _userQueryService.ReturnAllUsers();

            return Ok(results);
        }

       
    }
}
