using System;
using Domain;
using Domain.Interfaces;
using Domain.Services;
using Xunit;

namespace XUnitTestProject1
{
    public class MyFixture
    {
        public readonly IPricingService Ps;

        public MyFixture()
        {
            Ps = new PricingService();
        }
    }

    public class Pricing3_UnitTests : IClassFixture<MyFixture>
    {
        private readonly IPricingService ps_;

        public Pricing3_UnitTests(MyFixture myFixture)
        {
            ps_ = myFixture.Ps;
        }

        [Fact]
        public void DiscountPercentage_NullCheck()
        {
            // Arrange
            const decimal expectedDiscount = 0M;

            // Act
            var result = ps_.DiscountPercentage(null);

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
            Assert.Equal(expectedResult, ps_.DiscountPercentage(code));
        }
    }
}
