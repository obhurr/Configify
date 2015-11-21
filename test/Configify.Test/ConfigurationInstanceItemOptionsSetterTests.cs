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
    public class ConfigurationInstanceItemOptionsSetterTests
    {
        [Test]
        public void An_Option_Is_Added()
        {
            var instance = PizzaConfigurationBuilder.BuildInstanceWithNoSetOptions();

            var optionsSetter = new ConfigurationInstanceItemOptionsSetter();

            var size = instance.ConfigurationItemInstances.FirstOrDefault(i => i.ConfigurationItem.Name.Equals("Size"));
            Assert.IsNotNull(size);

            Assert.AreEqual(0, size.Options.Count);

            optionsSetter.Add(instance, new Option("Size", "Large"));

            Assert.AreEqual(1, size.Options.Count);
        }

        [Test]
        public void An_Option_Is_Removed()
        {
            var instance = PizzaConfigurationBuilder.BuildCompleteInstance();

            var optionsSetter = new ConfigurationInstanceItemOptionsSetter();

            var size = instance.ConfigurationItemInstances.FirstOrDefault(i => i.ConfigurationItem.Name.Equals("Size"));
            Assert.IsNotNull(size);

            Assert.AreEqual(1, size.Options.Count);

            optionsSetter.Remove(instance, new Option("Size", "Large"));

            Assert.AreEqual(0, size.Options.Count);
        }

        

    }
}
