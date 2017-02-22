using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using mcgtemplate_web.Config;
using mcgtemplate_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace mcgtemplate_web.Services
{
    // This class is used by the application to send Email and SMS.
    public class MessageSender : IMessageSender
    {
        private readonly twilioSettings _twilioSettings;

        public MessageSender(IOptions<twilioSettings> twilioSettings)
        {
            _twilioSettings = twilioSettings.Value;
        }

        public async Task<string> SendAsync(message model)
        {
            HttpResponseMessage result = new HttpResponseMessage();
            if (model.Type.Equals("sms"))
            {
                result = await SendSmsAsync(model.Number, model.Payload) as HttpResponseMessage;
            }
            else if (model.Type.Equals("voice"))
                result = await SendVoiceCallAsync(model.Number, model.Payload) as HttpResponseMessage;
            else
                return "Not Supported";

            if (result.IsSuccessStatusCode)
            {
                return "Ok";
            }
            else
            {
                return result.ReasonPhrase;
            }

        }


    public Task SendEmailAsync(string number, string message)
    {
        // Plug in your Email service here
        return Task.FromResult(0);
    }

    public async Task<HttpResponseMessage> SendVoiceCallAsync(string number, string twimlUrl)
    {
        //DEV: Currently, Twilio does not support .NET CORE.  Falling back on raw HttpClient until Twilio is ready.
        using (var client = new HttpClient { BaseAddress = new Uri(_twilioSettings.BaseUri) })
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_twilioSettings.Sid}:{_twilioSettings.Token}")));


                var content = new StringContent(string.Format($"From={_twilioSettings.From}&To={number}&Url={twimlUrl}"));

                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                
                // new KeyValuePair<string, string>("Url", twimlUrl)
                var result = await client.PostAsync(_twilioSettings.CallUri, content ).ConfigureAwait(false);

            return result;
        }

    }

    public async Task<HttpResponseMessage> SendSmsAsync(string number, string message)
    {
        //DEV: Currently, Twilio does not support .NET CORE.  Falling back on raw HttpClient until Twilio is ready.
        using (var client = new HttpClient { BaseAddress = new Uri(_twilioSettings.BaseUri) })
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_twilioSettings.Sid}:{_twilioSettings.Token}")));

            var content = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("To", $"+{number}"),
                    new KeyValuePair<string, string>("From", _twilioSettings.From),
                    new KeyValuePair<string, string>("Body", message)
                });

            var result = await client.PostAsync(_twilioSettings.SMSUri, content).ConfigureAwait(false);

            return result;
        }
    }
}
}
