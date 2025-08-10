using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth;
using SlimcareWeb.Service.Interfaces;

namespace SlimcareWeb.Service.Services
{
    public class GoogleService : IGoogleService
    {

        public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(string clientId, string tokenFromGG)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = new[] { clientId }
                };
                var payload = await GoogleJsonWebSignature.ValidateAsync(tokenFromGG, settings);
                return payload;
            }
            catch (Exception e)
            {
                throw new Exception("Invalid Google token.", e);
            }
        }

    }
}
