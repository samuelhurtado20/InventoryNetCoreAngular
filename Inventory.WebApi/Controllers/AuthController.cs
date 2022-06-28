using Inventory.Business.Interfaces;
using Inventory.Models;
using Inventory.WebApi.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Inventory.WebApi.Controllers
{
    [Route("api/auth")]
    public class AuthController
    {
        private ITokenProvider _tokenProvider;
        private ITokenBusiness _tokenBUS;

        public AuthController(ITokenProvider tokenProvider, ITokenBusiness tokenBUS)
        {
            _tokenProvider = tokenProvider;
            _tokenBUS = tokenBUS;
        }

        [HttpPost]
        public JsonWebToken Post([FromBody] User userLogin)
        {
            var user = _tokenBUS.ValidateUser(userLogin.Email, userLogin.Password);
            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            return new JsonWebToken
            {
                Access_Token = _tokenProvider.GetToken(user, DateTime.UtcNow.AddHours(8)),
                Expires_in = 480,

            };

        }
    }
}
