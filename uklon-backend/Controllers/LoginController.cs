using BissnesLogic.DTOs;
using BissnesLogic.Entites;
using BissnesLogic.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vonage;
using Vonage.Request;

namespace uklon_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        Random random = new Random();   

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login-phone")]
        public IActionResult LoginPhone(PhoneNumberVerificationDto phoneNumberDto)
        {
            // Отримати номер телефона користувача з phoneNumberDto
            string phoneNumber = phoneNumberDto.PhoneNumber;

            // Здійснити перевірку номера телефона шляхом відправки повідомлення
            bool isPhoneValid = SendVerificationMessage(phoneNumber);

            if (!isPhoneValid)
            {
                return BadRequest("Невірний номер телефона");
            }

            // Генерація JWT-токена
            var token = GenerateJwtToken(phoneNumber);

            // Повернути JWT-токен відповідь
            return Ok(new { Token = token });
        }

        private bool SendVerificationMessage(string phoneNumber)
        {
            int code = random.Next(1000, 9999);
            string apiKey = "3487d50a";
            string apiSecret = "yFZEZijVyklEgUS6";
            string from = "+380 97 003 2909";
            string message = $"Code pidtverdghnya: {code}";

            var credentials = Credentials.FromApiKeyAndSecret(apiKey, apiSecret);
            var vonageClient = new VonageClient(credentials);

            var response = vonageClient.SmsClient.SendAnSms(new Vonage.Messaging.SendSmsRequest
            {
                To = phoneNumber,
                From = from,
                Text = message
            });

            if (response.Messages[0].Status == "0")
            {
                // Повідомлення успішно відправлено
                return true;
            }
            else
            {
                // Сталася помилка при надсиланні повідомлення
                return false;
            }
        }

        private string GenerateJwtToken(string phoneNumber)
        {
            // Отримати параметри JWT-токена з конфігурації
            var jwtSettings = _configuration.GetSection("JwtSettings").Get<JwtSettings>();
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            // Задати клейми для JWT-токена (якщо потрібно)
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, phoneNumber)
        };

            // Створити JWT-токен
            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(jwtSettings.ExpirationMinutes),
                signingCredentials: signingCredentials
            );

            // Згенерувати строкове представлення JWT-токена
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return tokenString;
        }
    }
}
