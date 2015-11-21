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
    public class ConfigurationInstanceCompletenessEvaluatorTests
    {

        [Test]
        public void A_Complete_Instance_Returns_No_Errors()
        {
            var instance = PizzaConfigurationBuilder.BuildCompleteInstance();
            var evaluator = new ConfigurationInstanceCompletenessEvaluator();

            List<string> errors;
            evaluator.Evaluate(instance, out errors);

            Assert.IsEmpty(errors);
        }

        [Test]
        public void An_InComplete_Instance_Returns_Errors()
        {
            var instance = PizzaConfigurationBuilder.BuildInstanceWithNoSetOptions();
            var evaluator = new ConfigurationInstanceCompletenessEvaluator();

            List<string> errors;
            evaluator.Evaluate(instance, out errors);

            Assert.IsNotEmpty(errors);
        }


    }
}
