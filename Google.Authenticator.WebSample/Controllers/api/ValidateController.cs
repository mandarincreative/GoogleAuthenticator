using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Google.Authenticator.NETCore;
using Google.Authenticactor.WebSample.NETCore.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace mcgtemplate_web.Controllers.api
{
    [Route("api/[controller]")]
    public class ValidateController : Controller
    {
        // POST api/values
        [HttpGet("{key}")]
        public IActionResult Get(string key)
        {
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            var setupInfo = tfa.GenerateSetupCode("Test Two Factor", "user@example.com", key, 300, 300);

            string qrCodeImageUrl = setupInfo.QrCodeSetupImageUrl;
            string manualEntrySetupCode = setupInfo.ManualEntryKey;

            return Ok(new AuthData()
            {
                key = key,
                manualCode = manualEntrySetupCode,
                qrCode = qrCodeImageUrl
            });
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]AuthData auth)
        {
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            var result = tfa.ValidateTwoFactorPIN(auth.key, auth.code);
            var isValid = (result) ? String.Empty : "NOT";
            var validationMessage = auth.code + $" is a {isValid} valid PIN at UTC time " + DateTime.UtcNow.ToString();

            return Ok(new
            {
                isValid = result,
                message = validationMessage
            });
        }
    }
}
