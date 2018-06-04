using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
//using PremiumCalculator.Domain;
using PremiumCalculator.Service;

namespace PremiumCalculator.Tests
{
    [TestClass]
    public class PremiumCalculatorTest
    {
        private Service.PremiumCalculator _premiumCalculator;
        private Config _appConfig;

        [TestInitialize]
        public void setup()
        {
            _appConfig = new Config()
            {
                MaleGenderFactor = "1.2",
                FeMaleGenderFactor = "1.1",
                MinAge = "18",
                MaxAge = "65",
                Multiplier = "100"
            };
        }

        [TestMethod]
        public void calculatePremium_withValidAgeAndGenderAsMale_ReturnsValidPremium()
        {
            //Arrange
            _premiumCalculator = new Service.PremiumCalculator(_appConfig);
            //Act
            var resultObject = _premiumCalculator.CalculatePremium(36, "male");
            //Assert
            Assert.IsTrue(resultObject == 4320);
        }

        [TestMethod]
        public void calculatePremium_withValidAgeAndGenderAsFemale_ReturnsValidPremium()
        {
            //Arrange
            _premiumCalculator = new Service.PremiumCalculator(_appConfig);
            //Act
            var resultObject = _premiumCalculator.CalculatePremium(36, "female");
            //Assert
            Assert.IsTrue(resultObject == 3960);
        }
    }
}
