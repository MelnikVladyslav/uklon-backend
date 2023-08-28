using BissnesLogic.Entites;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace uklon_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly UklonDbContext _context;

        public TypesController(UklonDbContext context)
        {
            _context = context;
        }

        [HttpGet("get-types")]
        public async Task<ActionResult<IEnumerable<Types>>> GetTypes()
        {
            var types = await _context.Types.ToListAsync();
            return Ok(types);
        }

    }
}
