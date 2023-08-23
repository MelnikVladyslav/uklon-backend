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
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace uklon_backend.Controllers
{
    public class VerificationController : ControllerBase
    {
        private int Code = 0;
        Random rnd = new Random();

        public VerificationController()
        {
            Code = rnd.Next(1000,9999);
        }

        [HttpPost("verif-phone")]
        public bool VerificatePhoneNumberAsync()
        {
            SendSMSAsync();
                        

            return false;
        }

        private async void SendSMSAsync()
        {
            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = Environment.GetEnvironmentVariable("AC64091466eec192a51e0fce2ac48277e4");
            string authToken = Environment.GetEnvironmentVariable("9a8a75d86e160039fc91565d6f0e3ce9");

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Hello World!",
                from: new Twilio.Types.PhoneNumber("+1 762 248 8758"),
                to: new Twilio.Types.PhoneNumber("+38 098 762 2124")
            );

            Console.WriteLine(message.Sid);
        }

    }
}
