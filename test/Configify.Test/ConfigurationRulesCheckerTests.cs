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

        [Test]
        public void Min_Selected_Options_Rule_Returns_An_Error()
        {
            var checker = new ConfigurationRulesChecker();
            var configItem = new ConfigurationItem();
            configItem.ConfigurationItemOptions.Add( new ConfigurationItemOption {Name="Test", IsSelected = false});                
           
            string error;
            checker.MinSelectedOptionsRuleCheck(configItem, new MinSelectedOptionsRule {Count = 1},  out error);
            
            Assert.IsNotEmpty(error);
        }

        [Test]
        public void Min_Selected_Options_Rule_Does_Not_Return_An_Error()
        {
            var checker = new ConfigurationRulesChecker();
            var configItem = new ConfigurationItem();
            configItem.ConfigurationItemOptions.Add(new ConfigurationItemOption { Name = "Test", IsSelected = true});

            string error;
            checker.MinSelectedOptionsRuleCheck(configItem, new MinSelectedOptionsRule { Count = 1 }, out error);

            Assert.IsEmpty(error);
        }

        [Test]
        public void Max_Selected_Options_Rule_Returns_An_Error()
        {
            var checker = new ConfigurationRulesChecker();
            var configItem = new ConfigurationItem();
            configItem.ConfigurationItemOptions.Add(new ConfigurationItemOption { Name = "Test 1", IsSelected = true });
            configItem.ConfigurationItemOptions.Add(new ConfigurationItemOption { Name = "Test 2", IsSelected = true });

            string error;
            checker.MaxSelectedOptionsRuleCheck(configItem, new MaxSelectedOptionsRule { Count = 1 }, out error);

            Assert.IsNotEmpty(error);
        }

        [Test]
        public void Max_Selected_Options_Rule_Does_Not_Return_An_Error()
        {
            var checker = new ConfigurationRulesChecker();
            var configItem = new ConfigurationItem();
            configItem.ConfigurationItemOptions.Add(new ConfigurationItemOption { Name = "Test 1", IsSelected = true });
            configItem.ConfigurationItemOptions.Add(new ConfigurationItemOption { Name = "Test 2", IsSelected = true });

            string error;
            checker.MaxSelectedOptionsRuleCheck(configItem, new MaxSelectedOptionsRule { Count = 2 }, out error);

            Assert.IsEmpty(error);
        }
    }
}
