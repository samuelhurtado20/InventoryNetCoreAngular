using FluentAssertions;
using Inventory.Business.Implementations;
using Inventory.Business.Interfaces;
using Inventory.Models;
using Inventory.Tests.Mocked;
using Inventory.UnitOfWork;
using Xunit;

namespace Inventory.Tests
{
    public  class CustomerBusinessTest
    {
        private readonly IUnitOfWork _uMocked;
        private readonly ICustomerBusiness _customerMocked;

        public CustomerBusinessTest()
        {
            var unitMocked = new CustomerRepositoryMocked();
            _uMocked = unitMocked.GetInstance();
            _customerMocked = new CustomerBusiness(_uMocked);
        }

        [Fact]
        public void GetById()
        {
            var result = _customerMocked.GetById(1);
            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Insert()
        {
            Customer customer = new ()
            {
                Id = 51,
                City = "Quito",
                Country = "Ecuador",
                FirstName = "Eduardo",
                LastName = "Garcia",
                Phone = "987654321"
            };
            var result = _customerMocked.Insert(customer);
            result.Should().NotBeNull();
            result.Id.Should().Be(51);
        }

        [Fact]
        public void Update()
        {
            Customer customer = new()
            {
                Id = 52,
                City = "Quito",
                Country = "Ecuador",
                FirstName = "Eduardo",
                LastName = "Garcia",
                Phone = "987654321"
            };
            var result = _customerMocked.Update(customer);
            result.Should().BeTrue();

            var customerUpdated = _customerMocked.GetById(customer.Id);
            customerUpdated.Should().NotBeNull();
            customerUpdated.LastName.Should().Be(customer.LastName);
        }
    }
}
