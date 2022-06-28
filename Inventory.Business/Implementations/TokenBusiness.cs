using Inventory.Business.Interfaces;
using Inventory.Models;
using Inventory.UnitOfWork;

namespace Inventory.Business.Implementations
{
    public class TokenBusiness : ITokenBusiness
    {
        private readonly IUnitOfWork _uow;
        public TokenBusiness(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public User ValidateUser(string email, string password)
        {
            return _uow.User.ValidateUser(email, password);
        }
    }
}
