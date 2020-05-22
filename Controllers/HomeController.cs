using Microsoft.AspNetCore.Mvc;

namespace ShopWarehouse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult Hello()
        {
            return Ok("Hello");
        }
    }
}
