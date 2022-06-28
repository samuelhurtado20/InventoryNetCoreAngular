using Inventory.Models;

namespace Inventory.Business.Interfaces
{
    public interface ITokenBusiness
    {
        User ValidateUser(string email, string password);
    }
}
