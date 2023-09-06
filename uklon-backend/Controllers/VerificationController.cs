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
using Microsoft.Extensions.Configuration;
using Infobip.Api.Client;
using Infobip.Api.Client.Api;
using Infobip.Api.Client.Model;
using Twilio.TwiML.Messaging;
using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Vonage.Request;
using Vonage;
using Inetlab.SMPP.Multimedia;
using MimeKit;

namespace uklon_backend.Controllers
{
    public class VerificationController : ControllerBase
    {
        private int Code = 0;
        Random rnd = new Random();

        //Infobip
        /*string BASE_URL = "https://zjw9e6.api.infobip.com";
        string API_KEY = "c8dd9f00f407c4d2e873d266c7357bd6-958b431c-6834-48d2-b325-b3ce2cdf673a";
        string SENDER = "Drive";*/

        public VerificationController()
        {
            Code = rnd.Next(1000, 9999);
        }

        [HttpPost("verif-phone")]
        public int VerificatePhoneNumberAsync(PhoneNumberVerificationDto phoneNumberDto)
        {
            string phoneNumber = phoneNumberDto.PhoneNumber;
            SendSMSAsync(phoneNumber); 
            return Code;
        }

        [HttpPost("verif-email")]
        public int VerificateEmailAsync(PhoneNumberVerificationDto phoneNumberDto)
        {
            string email = phoneNumberDto.Email;
            SendEmailAsync(email);
            return Code;
        }

        private async void SendSMSAsync(string RECIPIENT)
        {
            //Vonage
            var credentials = Credentials.FromApiKeyAndSecret(
                "785dfa2f",
                "llGJoI207HTOOZzW"
                );

            var VonageClient = new VonageClient(credentials);

            var response = VonageClient.SmsClient.SendAnSms(new Vonage.Messaging.SendSmsRequest()
            {
                To = RECIPIENT,
                From = "Drive",
                Text = "Your Drive verification code: " + Code
            });

            //Infobip
            /*string MESSAGE_TEXT = "Your Drive verification code: " + Code;

            var configuration = new Configuration()
            {
                BasePath = BASE_URL,
                ApiKeyPrefix = "App",
                ApiKey = API_KEY
            };

            var sendSmsApi = new SendSmsApi(configuration);
            var smsMessage = new SmsTextualMessage()
            {
                From = SENDER,
                Destinations = new List<SmsDestination>()
                {
                    new SmsDestination(to: RECIPIENT)
                },
                Text = MESSAGE_TEXT
            };

            var smsRequest = new SmsAdvancedTextualRequest()
            {
                Messages = new List<SmsTextualMessage>() { smsMessage }
            };

            try
            {
                var smsResponse = sendSmsApi.SendSmsMessage(smsRequest);
            }
            catch (ApiException apiException)
            {
                throw (System.Exception)apiException.ErrorContent;
            }*/
        }

        private void SendEmailAsync(string Email)
        {
            string htmlBody = $@"<!DOCTYPE html>
            <html lang=""""en"""">
            <head>
                <meta charset=""""UTF-8"""">
                <meta name=""""viewport"""" content=""""width=device-width, initial-scale=1.0"""">
                <title>Код підтвердження</title>
            </head>
            <body>
                <h1>Код підтвердження</h1>
                <p>Ваш код підтвердження: <strong>{Code}</strong></p>
                <p>Цей код використовується для підтвердження вашого облікового запису.</p>
            </body>
            </html>";

            MailAddress from = new MailAddress("drivetaxi22@gmail.com", "Drive");
            MailAddress to = new MailAddress(Email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Code";
            m.IsBodyHtml = true;
            m.Body = htmlBody;
            //m.Body = "Your verification Drive code: " + Code;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("drivetaxi22@gmail.com", "ecwfmopcklppqvzv"),
                EnableSsl = true
            };
            smtp.Send(m);
        }
    }
}
