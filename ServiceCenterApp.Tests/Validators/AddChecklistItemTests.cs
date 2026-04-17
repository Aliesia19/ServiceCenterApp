using Xunit;
using AutoFixture;
using ServiceCenterApp.Application.Commands;
using ServiceCenterApp.Application.Validators;
using System;

namespace ServiceCenterApp.Tests.Validators
{
    public class AddChecklistItemTests
    {
        private readonly AddChecklistItemValidator _validator;
        private readonly Fixture _fixture;

        public AddChecklistItemTests()
        {
            _validator = new AddChecklistItemValidator();
            _fixture = new Fixture();
        }

        [Fact]
        public void Should_Throw_When_RequestId_Empty()
        {
            var command = _fixture.Create<AddChecklistItemCommand>();
            command.RequestId = Guid.Empty;

            var ex = Assert.Throws<Exception>(() => _validator.Validate(command));

            Assert.Equal("RequestId is required", ex.Message);
        }

        [Fact]
        public void Should_Throw_When_ServiceId_Empty()
        {
            var command = _fixture.Create<AddChecklistItemCommand>();
            command.ServiceId = Guid.Empty;

            var ex = Assert.Throws<Exception>(() => _validator.Validate(command));

            Assert.Equal("ServiceId is required", ex.Message);
        }

        [Fact]
        public void Should_Throw_When_Quantity_Invalid()
        {
            var command = _fixture.Create<AddChecklistItemCommand>();
            command.Quantity = 0;

            var ex = Assert.Throws<Exception>(() => _validator.Validate(command));

            Assert.Equal("Quantity must be greater than 0", ex.Message);
        }

        [Fact]
        public void Should_Not_Throw_When_Valid()
        {
            var command = _fixture.Create<AddChecklistItemCommand>();

            var exception = Record.Exception(() => _validator.Validate(command));

            Assert.Null(exception);
        }
    }
}