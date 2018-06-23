using Domain;
using Domain.Services;
using Xunit;

namespace XUnitTestProject1
{
    public class Pricing2_UnitTests
    {
        [Fact]
        public void DiscountPercentage_NullCheck()
        {
            // Arrange
            const decimal expectedDiscount = 0M;
            var ps = new PricingService();

            // Act
            var result = ps.DiscountPercentage(null);

            // Assert
            Assert.Equal(expectedDiscount, result);
        }

        [Theory]
        [InlineData(0, "03aaa")]
        [InlineData(0, "17abc")]
        [InlineData(0, "99edf")]
        [InlineData(0, "10edfddd")]
        [InlineData(0, "20")]
        [InlineData(0, "xxxxxxxxxxxx")]
        public void DiscountPercentage_Zero(decimal expectedResult, string code)
        {
            var ps = new PricingService();

            Assert.Equal(expectedResult, ps.DiscountPercentage(code));
        }
    }
}
