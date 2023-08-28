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
using Infobip.Api.Client.Api;
using Infobip.Api.Client.Model;
using Infobip.Api.Client;
using Microsoft.Extensions.Configuration;


namespace uklon_backend.Controllers
{
    public class VerificationController : ControllerBase
    {
        private int Code = 0;
        Random rnd = new Random();
        string BASE_URL = "https://zjw9e6.api.infobip.com";
        string API_KEY = "c8dd9f00f407c4d2e873d266c7357bd6-958b431c-6834-48d2-b325-b3ce2cdf673a";
        string SENDER = "Drive";

        public VerificationController()
        {
            Code = rnd.Next(1000, 9999);
        }

        [HttpPost("verif-phone")]
        public bool VerificatePhoneNumberAsync(PhoneNumberVerificationDto phoneNumberDto)
        {
            string phoneNumber = phoneNumberDto.PhoneNumber;
            SendSMSAsync(phoneNumber); // Відправка смс працює лише з номерами з білого списку сервісу
            return false;
        }

        private async void SendSMSAsync(string RECIPIENT)
        {
            string MESSAGE_TEXT = "Your Drive verification code: " + Code;

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
            }
        }
    }
}
