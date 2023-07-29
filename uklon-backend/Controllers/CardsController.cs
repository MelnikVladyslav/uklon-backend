using BissnesLogic.DTOs;
using BissnesLogic.Entites;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace uklon_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UklonDbContext _context;

        public CardsController(IConfiguration configuration,
                              UklonDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("add-card")]
        public async Task<IActionResult> AddCard(CardDTO card)
        {
            Card newCard = new Card()
            {
                Number = card.Number,
                UserId = card.UserId,
            };

            try
            {
                // Додати модель до контексту та зберегти зміни
                _context.Cards.Add(newCard);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException;

                return StatusCode(500, $"Помилка при збереженні даних: {innerException.Message}, {innerException.StackTrace}");
            }
        }

        [HttpGet("get-cards")]
        public async Task<ActionResult<IEnumerable<Card>>> GetCards()
        {
            var cards = await _context.Cards.ToListAsync();
            return Ok(cards);
        }
    }
}
