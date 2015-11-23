using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configify
{
    public class ConfigurationPriceCalculator
    {
        public decimal Calculate(Configuration configuration)
        {
            var price = configuration.Price;

            foreach (var configurationItem in configuration.ConfigurationItems)
            {
                price += configurationItem.Price;

                price += configurationItem.ConfigurationItemOptions
                    .Where(i => i.IsSelected)
                    .Sum(configurationItemOption => configurationItemOption.Price);
            }
            return price;
        }
    }
}
