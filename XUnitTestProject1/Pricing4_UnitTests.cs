using System;
using Domain;
using Domain.Interfaces;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace XUnitTestProject1
{
    public class MyFixture4
    {
        private IServiceProvider container_;

        public MyFixture4()
        {
            container_ = new ServiceCollection()
                .AddSingleton<IPricingService, PricingService>()
                .BuildServiceProvider();
        }

        public T Resolve<T>()
        {
            return container_.GetService<T>();
        }
    }

    public class Pricing4_UnitTests : IClassFixture<MyFixture4>
    {
        private readonly IPricingService ps_;

        public Pricing4_UnitTests(MyFixture4 myFixture)
        {
            ps_ = myFixture.Resolve<IPricingService>();
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
