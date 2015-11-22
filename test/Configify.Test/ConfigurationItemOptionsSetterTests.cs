using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace Configify.Test
{
    [TestFixture]
    public class ConfigurationItemOptionsSetterTests
    {
        [Test]
        public void An_Option_Is_Set()
        {
            var configuration = PizzaConfigurationBuilder.BuildWithNoSetOptions();

            var optionsSetter = new ConfigurationItemOptionsSetter();

            var size = configuration.ConfigurationItems.FirstOrDefault(i => i.Name.Equals("Size"));

            Assert.IsNotNull(size);

            var largeOption =
                size.ConfigurationItemOptions.FirstOrDefault(
                    o => o.Name.Equals("Large", StringComparison.OrdinalIgnoreCase));

            Assert.IsNotNull(largeOption);

            Assert.IsFalse(largeOption.IsSelected);

            optionsSetter.SetOrUnSet(configuration.ConfigurationItems, "Size", "Large", true);

            Assert.IsTrue(largeOption.IsSelected);
        }

        [Test]
        public void An_Option_Is_UnSet()
        {
            var configuration = PizzaConfigurationBuilder.BuildCompleteInstance();

            var optionsSetter = new ConfigurationItemOptionsSetter();

            var size = configuration.ConfigurationItems.FirstOrDefault(i => i.Name.Equals("Size"));

            Assert.IsNotNull(size);

            var largeOption =
                size.ConfigurationItemOptions.FirstOrDefault(
                    o => o.Name.Equals("Large", StringComparison.OrdinalIgnoreCase));

            Assert.IsNotNull(largeOption);

            Assert.IsTrue(largeOption.IsSelected);

            optionsSetter.SetOrUnSet(configuration.ConfigurationItems, "Size", "Large", false);

            Assert.IsFalse(largeOption.IsSelected);
        }

        

    }
}
