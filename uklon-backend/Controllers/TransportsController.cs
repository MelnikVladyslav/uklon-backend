using BissnesLogic.Entites;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace uklon_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportsController : ControllerBase
    {
        private readonly UklonDbContext _context;

        public TransportsController(UklonDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transport>>> GetTransports()
        {
            var transports = await _context.Transports.ToListAsync();
            return Ok(transports);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Transport model)
        {
            try
            {
                // Додати модель до контексту та зберегти зміни
                _context.Transports.Add(model);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException;

                return StatusCode(500, $"Помилка при збереженні даних: {innerException.Message}, {innerException.StackTrace}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Transport model)
        {
            try
            {
                // Пошук моделі за ідентифікатором
                var existingModel = await _context.Transports.FindAsync(id);

                if (existingModel == null)
                    return NotFound();

                // Оновлення полів моделі
                existingModel.Model = model.Model;
                existingModel.Description = model.Description;

                // Зберегти зміни
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Помилка при оновленні даних: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                // Пошук моделі за ідентифікатором
                var existingModel = await _context.Transports.FindAsync(id);

                if (existingModel == null)
                    return NotFound();

                // Видалення моделі з контексту
                _context.Transports.Remove(existingModel);

                // Зберегти зміни
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Помилка при видаленні даних: {ex.Message}");
            }
        }
    }
}
