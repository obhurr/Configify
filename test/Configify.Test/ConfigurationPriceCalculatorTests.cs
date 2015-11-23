using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Configify.Test
{
    [TestFixture]
    public class ConfigurationPriceCalculatorTests
    {
        [Test]
        public void Does_Calculate_Correctly()
        {
            var config = new Configuration
            {
                Price = 1.00m
            };

            var configItem = new ConfigurationItem
            {
                Price = .25m
            };

            configItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                IsSelected =  true,
                Price = 3.10m
            });

            configItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                IsSelected = false,
                Price = 3.10m
            });

            config.ConfigurationItems.Add(configItem);

            var calculator = new ConfigurationPriceCalculator();
            var result = calculator.Calculate(config);

            Assert.AreEqual(4.35m, result);
        }
    }
}
