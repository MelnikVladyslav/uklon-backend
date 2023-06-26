using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Drive.Models;
using Drive.Data;

namespace Drive.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DriveSwagController : ControllerBase
    {
        private readonly ApiContext _context;

        public DriveSwagController(ApiContext context)
        {
            _context = context;
        }

        // create/edit
        [HttpPost]
        public JsonResult CreateEdit(User user)
        {
            if(user.Id == 0)
            {
                _context.User.Add(user)
            }
        }


	}
}