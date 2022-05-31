using Card.Domain.Entities.CardAggregate;
using Card.Domain.Interfaces;
using Card.Domain.Services;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Card.Domain.Tests.Services
{
    public class CardServiceTests
    {

        [Fact]
        public void Must_Save_Card()
        {
            var id = Guid.NewGuid();
            CustomerCard customerCard = new CustomerCard(id, 1, 123456789, 527);

            Mock<ICardRepository> _mockRepo = new Mock<ICardRepository>();
            Mock<ICacheService> _mockCache = new Mock<ICacheService>();
            _mockCache.Setup(p => p.CacheToken(It.IsAny<long>())).Returns(1234);
            _mockCache.Setup(p => p.Get(It.IsAny<long>())).Returns(1234);
            CardService _service = new CardService(_mockRepo.Object, _mockCache.Object);
            var result = _service.Save(customerCard);
            var token = _service.GenerateToken(customerCard.CardNumber, customerCard.Cvv);

            Assert.Equal(customerCard.CustomerId, result.CustomerId);
            Assert.Equal(customerCard.Cvv, result.Cvv);
            Assert.Equal(customerCard.CardNumber, result.CardNumber);
            Assert.Equal(token, result.Token);
        }

        [Fact]
        public void Must_Validate_Card()
        {
            Guid id;
            CardService _service;
            LoadMock(out id, out _service);

            var result = _service.Validate(id, 1, 527, 2341);
            Assert.True(result);

        }

        [Fact]
        public void Must_Be_Invalid_Cvv()
        {
            Guid id;
            CardService _service;
            LoadMock(out id, out _service);

            var result = _service.Validate(id, 1, 528, 2341);
            Assert.False(result);

        }

        [Fact]
        public void Must_Be_Invalid_Token()
        {
            Guid id;
            CardService _service;
            LoadMock(out id, out _service);

            var result = _service.Validate(id, 1, 527, 2342);
            Assert.False(result);

        }

        [Fact]
        public void Must_Be_Invalid_CustomerId()
        {
            Guid id;
            CardService _service;
            LoadMock(out id, out _service);

            var result = _service.Validate(id, 2, 527, 2341);
            Assert.False(result);

        }

        private static void LoadMock(out Guid id, out CardService _service)
        {
            id = Guid.NewGuid();
            CustomerCard customerCard = new CustomerCard(id, 1, 123451234, 527);

            Mock<ICardRepository> _mockRepo = new Mock<ICardRepository>();
            Mock<ICacheService> _mockCache = new Mock<ICacheService>();
            _mockCache.Setup(p => p.CacheToken(It.IsAny<long>())).Returns(2341);
            _mockCache.Setup(p => p.Get(It.IsAny<long>())).Returns(2341);
            _mockRepo.Setup(p => p.Get(It.IsAny<Guid>())).Returns(customerCard);
            _service = new CardService(_mockRepo.Object, _mockCache.Object);
        }
    }
}
