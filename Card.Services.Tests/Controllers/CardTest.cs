using Card.Domain.Entities;
using Card.Domain.Entities.CardAggregate;
using Card.Domain.Interfaces;
using Card.Service.Controllers;
using Card.Service.Dtos;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace Card.Services.Tests
{
    public class CardTest
    {
        [Fact]
        public void Must_Save_Card()
        {
            var id = Guid.NewGuid();
            CustomerCard customerCard = new CustomerCard(id, 1, 123456789, 527);
            SaveCardDto saveCardDto = new SaveCardDto(1, 123456789, 527);

            Mock<ICardService> _mockService = new Mock<ICardService>();
            CardController controller = new CardController(_mockService.Object);
            _mockService.Setup(x => x.Save(It.IsAny<CustomerCard>())).Returns(customerCard);

            var result = (OkObjectResult)controller.Post(saveCardDto);

            Assert.Equal(id, ((SavedCardDto)result.Value).CardId);
        }

        [Fact]
        public void Must_Validate_Card()
        {
            var id = Guid.NewGuid();
            ValidateCardDto validateCardDto = new ValidateCardDto(id, 1234, 527, 1);

            Mock<ICardService> _mockService = new Mock<ICardService>();
            CardController controller = new CardController(_mockService.Object);
            _mockService.Setup(x => x.Validate(id, 1, 527, 1234)).Returns(true);

            var result = (OkObjectResult)controller.Validate(validateCardDto);

            Assert.True((bool)result.Value);
        }
    }
}
