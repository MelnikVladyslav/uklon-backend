using BissnesLogic.DTOs;
using BissnesLogic.Entites;
using BissnesLogic.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Text;
using Data;
using Inetlab.SMPP;
using Inetlab.SMPP.PDU;
using Twilio.Jwt.AccessToken;


namespace uklon_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class DeleteUserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly UklonDbContext _context;

        public DeleteUserController(IConfiguration configuration,
                              UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              UklonDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _configuration = configuration;
            _context = context;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(User user)
        {
            var delUser = await userManager.FindByIdAsync(user.Id);

            if (delUser == null)
            {
                return NotFound();
            }

            await userManager.DeleteAsync(delUser);

            return Ok();
        }
    }
}
