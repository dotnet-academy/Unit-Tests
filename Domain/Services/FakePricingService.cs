using Domain.Interfaces;

namespace Domain.Services
{
    public class FakePricingService : IPricingService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public decimal DiscountPercentage(string code)
        {
            return 0M;
        }
    }
}
