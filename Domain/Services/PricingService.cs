﻿using Domain.Interfaces;

namespace Domain.Services
{
    public class PricingService : IPricingService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public decimal DiscountPercentage(string code)
        {
            var discount = 0M;

            if (code == null) {
                return 0M;
            }

            if (code.Trim().Length != 5) {
                return 0M;
            }

            if (code.StartsWith("10")) {
                discount = 10M;
            }

            if (code.StartsWith("20")) {
                discount = 20M;
            }

            if (code.Contains("x")) {
                var xCounter = code.Split('x').Length - 1;

                if (xCounter > 0) {
                    discount += xCounter;
                }
            }

            return discount;
        }
    }
}
