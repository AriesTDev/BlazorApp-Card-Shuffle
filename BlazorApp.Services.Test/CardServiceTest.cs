using BlazorApp.Services.Implementations;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace BlazorApp.Services.Test
{
    [TestFixture]
    public class CardServiceTest
    {
        private Mock<ILogger<CardService>> _logger;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<CardService>>();
        }

        [Test]
        public void GetInitialCards_ShouldNotThrowException_WhenReturn52CountOfCards()
        {
            //arrange
            var expectedResult = 52;
            var cardService = new CardService(_logger.Object);
            //act
            var result = cardService.GetInitialCards().Count();
            //assert
            result.Should().Equals(expectedResult);
        }

        [Test]
        public void ShuffleCards_ShouldNotThrowException_WhenReturn52CountOfCards()
        {
            //arrange
            var expectedResult = 52;

            var cardService = new CardService(_logger.Object);
            //act
            var result = cardService.ShuffleCards().Count();
            //assert
            result.Should().Equals(expectedResult);
        }
    }
}