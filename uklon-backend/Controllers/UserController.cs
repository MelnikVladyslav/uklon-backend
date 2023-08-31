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


namespace uklon_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly UklonDbContext _context;

        public UserController(IConfiguration configuration,
                              UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              UklonDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _configuration = configuration;
            _context = context;
        }

        [HttpPut("make-applicaiton")]
        public async Task<IActionResult> MakeApplicationAsync(User _user)
        {

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(PhoneNumberVerificationDto phoneNumberDto)
        {
            string phoneNumber = phoneNumberDto.PhoneNumber;

            var user = await userManager.FindByNameAsync(phoneNumber);

            if (user == null)
            {
                return NotFound();
            }

            userManager.DeleteAsync(user);

            return Ok();
        }
    }
}
