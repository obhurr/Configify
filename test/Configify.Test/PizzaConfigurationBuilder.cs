using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Configify;

namespace Configify.Test
{
    public class PizzaConfigurationBuilder
    {

        public Configuration Build()
        {
            var pizza = new Configuration
            {
                Name = "Pizza",
                Description = "Build your own Pizza"
            };

            pizza.ConfigurationItems.Add(BuildSizeItem(1));
            pizza.ConfigurationItems.Add(BuildCrustItem(2));
            pizza.ConfigurationItems.Add(BuildToppingsItem(3));

            return pizza;
        }

        public static ConfigurationInstance BuildCompleteInstance()
        {
            var configurationBuilder = new PizzaConfigurationBuilder();
            var configuration = configurationBuilder.Build();

            var instance = ConfigurationInstance.Build(configuration);

            var optionsSetter = new ConfigurationInstanceItemOptionsSetter();

            optionsSetter.Add(instance, new Option("Size", "Large"));
            optionsSetter.Add(instance, new Option("Crust", "Thick"));
            optionsSetter.Add(instance, new Option("Toppings", "Extra Cheese"));
            optionsSetter.Add(instance, new Option("Toppings", "Pepperoni"));

            return instance;
        }

        public static ConfigurationInstance BuildInstanceWithNoSetOptions()
        {
            var configurationBuilder = new PizzaConfigurationBuilder();
            var configuration = configurationBuilder.Build();

            var instance = ConfigurationInstance.Build(configuration);

            return instance;
        }

        private ConfigurationItem BuildSizeItem(int sequence)
        {
            var rule = new ConfigurationItem
            {
                Name = "Size",
                Sequence = sequence,
                OptionsMinCount = 1,
                OptionsMaxCount = 1,
                EndUserInstructions = "Choose your Size"
            };

            rule.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Small",
                Description = "4 slices, feeds 1 person",
                Sequence = 1
            });

            rule.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Medium",
                Description = "8 slices, feeds 2 people",
                Sequence = 2
            });

            rule.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Large",
                Description = "16 slices, feeds 3 or 4 people",
                Sequence = 3
            });

            return rule;
        }

        private ConfigurationItem BuildCrustItem(int sequence)
        {
            var rule = new ConfigurationItem
            {
                Name = "Crust",
                Sequence = sequence,
                OptionsMinCount = 1,
                OptionsMaxCount = 1,
                EndUserInstructions = "Choose your Crust"
            };

            rule.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Thin",
                Sequence = 1
            });

            rule.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Thick",
                Sequence = 2
            });

            rule.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Cheese Filled",
                Sequence = 3
            });

            return rule;
        }

        private ConfigurationItem BuildToppingsItem(int sequence)
        {
            var rule = new ConfigurationItem
            {
                Name = "Toppings",
                Sequence = sequence,
                OptionsMinCount = 1,
                OptionsMaxCount = 99,
                EndUserInstructions = "Choose your toppings"
            };

            rule.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Extra Cheese",
                Sequence = 1
            });

            rule.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Pepperoni",
                Sequence = 2
            });

            rule.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Sausage",
                Sequence = 3
            });

            rule.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Canadian Bacon",
                Sequence = 4
            });

            rule.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Mushrooms",
                Sequence = 5
            });

            return rule;
        }
    }
}
