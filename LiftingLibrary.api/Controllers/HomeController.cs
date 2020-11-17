using Microsoft.AspNetCore.Mvc;

namespace LiftingLibrary.api.Controllers
{   
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "Hello world";
        }
    }
}