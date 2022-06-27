using Inventory.Models;
using Inventory.UnitOfWork;
using Inventory.WebApi.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Inventory.WebApi.Controllers
{
    [Route("api/auth")]
    public class AuthController
    {
        private ITokenProvider _tokenProvider;
        private IUnitOfWork _unitOfWork;

        public AuthController(ITokenProvider tokenProvider, IUnitOfWork unitOfWork)
        {
            _tokenProvider = tokenProvider;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public JsonWebToken Post([FromBody] User userLogin)
        {
            var user = _unitOfWork.User.ValidateUser(userLogin.Email, userLogin.Password);
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
