using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class DiscountMath
    {
        public static double PriceToPercent(double newPrice, double oldPrice)
        {
            return (1 - newPrice / oldPrice) * 100;
        }
        public static double PercentToPrice(double percent, double oldPrice)
        {
            return (1 - percent / 100) * oldPrice;
        }
    }
}
