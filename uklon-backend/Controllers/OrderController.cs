using BissnesLogic.DTOs;
using BissnesLogic.Entites;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace uklon_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly UklonDbContext _context;

        public OrderController(UklonDbContext context)
        {
            _context = context;
        }

        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder(OrderDTO order)
        {
            Order newOrder = new Order()
            {
                Date = order.Date,
                StartPoint = order.StartPoint,
                EndPoint = order.EndPoint,
                TotalPrice = order.TotalPrice,
                Rating = order.Rating,
                Type = order.Type,
                UserId = order.UserId,
            };

            try
            {
                _context.Orders.Add(newOrder);
                await _context.SaveChangesAsync();

                return Ok(order);
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException;

                return StatusCode(500, $"Помилка при збереженні даних: {innerException.Message}, {innerException.StackTrace}");
            }
        }

        [HttpGet("get-orders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _context.Orders.ToListAsync();
            return Ok(orders);
        }

        [HttpPut("set-rating")]
        public async Task<IActionResult> SetRatingAsync(int rating, Order order)
        {
            if (rating <= 0 || rating > 5)
                return BadRequest();

            _context.Orders.Find(order).Rating = rating;
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
