using BissnesLogic.DTOs;
using BissnesLogic.Entites;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace uklon_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderHistoryController : ControllerBase
    {
        private readonly UklonDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public OrderHistoryController(IConfiguration configuration,
                              UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              UklonDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _configuration = configuration;
            _context = context;
        }

        public OrderHistoryController(UklonDbContext context)
        {
            _context = context;
        }

        [HttpGet("getHistory")]
        public async Task<List<Order>> GetOrdersHistoryAsync(PhoneNumberVerificationDto verificationDto)
        {
            List<Order> orderHistory = new List<Order>();

            string phoneNumber = verificationDto.PhoneNumber;
            string email = verificationDto.Email;

            var user = await userManager.FindByNameAsync(phoneNumber);

            if (phoneNumber == null)
            {
                user = await userManager.FindByNameAsync(phoneNumber);
            }

            orderHistory.AddRange(_context.Orders.Where(e => e.UserId == user.Id));

            return orderHistory;
        }

    }
}
