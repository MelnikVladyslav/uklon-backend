using BissnesLogic.DTOs;
using BissnesLogic.Entites;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace uklon_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectedAdressesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UklonDbContext _context;

        public SelectedAdressesController(IConfiguration configuration,
                              UklonDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SelAdress>>> GetSelAdress()
        {
            var selAdres = await _context.SelAdresses.ToListAsync();
            return Ok(selAdres);
        }

        [HttpPost]
        public async Task<ActionResult> AddFavAdress(SelAdresessDTO selAdressDTO)
        {
            SelAdress newSelAdress = new SelAdress()
            {
                NameHome = selAdressDTO.NameHome,
                NameAdr = selAdressDTO.NameAdr,
                NameJob = selAdressDTO.NameJob,
                UserId = selAdressDTO.UserId,
            };

            try
            {
                // Додати модель до контексту та зберегти зміни
                _context.SelAdresses.Add(newSelAdress);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException;

                return StatusCode(500, $"Помилка при збереженні даних: {innerException.Message}, {innerException.StackTrace}");
            }
        }
    }
}
