using Inventory.Models;
using Microsoft.IdentityModel.Tokens;
using System;

namespace Inventory.WebApi.Authentication
{
    public interface ITokenProvider
    {
        string GetToken(User user, DateTime expiry);
        TokenValidationParameters GetValidationParameters();
    }
}
