using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Configify;
using NUnit;
using NUnit.Framework;

namespace Configify.Test
{
    [TestFixture]
    public class ConfigurationRulesCheckerTests
    {

        [Test]
        public void A_Complete_Instance_Returns_No_Errors()
        {
            var configuration = PizzaConfigurationBuilder.BuildCompleteInstance();
            var checker = new ConfigurationRulesChecker();

            List<string> errors;
            checker.Check(configuration, out errors);

            Assert.IsEmpty(errors);
        }

        [Test]
        public void An_InComplete_Instance_Returns_Errors()
        {
            var configuration = PizzaConfigurationBuilder.BuildWithNoSetOptions();
            var checker = new ConfigurationRulesChecker();

            List<string> errors;
            checker.Check(configuration, out errors);

            Assert.IsNotEmpty(errors);
        }


    }
}
