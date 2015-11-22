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

        public static Configuration BuildCompleteInstance()
        {
            var configurationBuilder = new PizzaConfigurationBuilder();
            var configuration = configurationBuilder.Build();

            var optionsSetter = new ConfigurationItemOptionsSetter();

            optionsSetter.SetOrUnSet(configuration.ConfigurationItems, "Size", "Large", true);
            optionsSetter.SetOrUnSet(configuration.ConfigurationItems, "Crust", "Thick", true);
            optionsSetter.SetOrUnSet(configuration.ConfigurationItems, "Toppings", "Extra Cheese", true);
            optionsSetter.SetOrUnSet(configuration.ConfigurationItems, "Toppings", "Pepperoni", true);

            return configuration;
        }

        public static Configuration BuildWithNoSetOptions()
        {
            var configurationBuilder = new PizzaConfigurationBuilder();
            var configuration = configurationBuilder.Build();
            return configuration;
        }

        private ConfigurationItem BuildSizeItem(int sequence)
        {
            var configurationItem = new ConfigurationItem
            {
                Name = "Size",
                Sequence = sequence,
                OptionsMinCount = 1,
                OptionsMaxCount = 1,
                EndUserInstructions = "Choose your Size"
            };

            configurationItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Small",
                Description = "4 slices, feeds 1 person",
                Sequence = 1
            });

            configurationItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Medium",
                Description = "8 slices, feeds 2 people",
                Sequence = 2
            });

            configurationItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Large",
                Description = "16 slices, feeds 3 or 4 people",
                Sequence = 3
            });

            return configurationItem;
        }

        private ConfigurationItem BuildCrustItem(int sequence)
        {
            var configurationItem = new ConfigurationItem
            {
                Name = "Crust",
                Sequence = sequence,
                OptionsMinCount = 1,
                OptionsMaxCount = 1,
                EndUserInstructions = "Choose your Crust"
            };

            configurationItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Thin",
                Sequence = 1
            });

            configurationItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Thick",
                Sequence = 2
            });

            configurationItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Cheese Filled",
                Sequence = 3
            });

            return configurationItem;
        }

        private ConfigurationItem BuildToppingsItem(int sequence)
        {
            var configurationItem = new ConfigurationItem
            {
                Name = "Toppings",
                Sequence = sequence,
                OptionsMinCount = 1,
                OptionsMaxCount = 99,
                EndUserInstructions = "Choose your toppings"
            };

            configurationItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Extra Cheese",
                Sequence = 1
            });

            configurationItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Pepperoni",
                Sequence = 2
            });

            configurationItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Sausage",
                Sequence = 3
            });

            configurationItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Canadian Bacon",
                Sequence = 4
            });

            configurationItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Mushrooms",
                Sequence = 5
            });

            return configurationItem;
        }

        private void ReadMeExample()
        {
            //Get our configuration for a pizza
            var configurationBuilder = new PizzaConfigurationBuilder();
            var configuration = configurationBuilder.Build();

            //Set our options
            var optionsSetter = new ConfigurationItemOptionsSetter();
            optionsSetter.SetOrUnSet(configuration.ConfigurationItems, "Size", "Large", true);
            optionsSetter.SetOrUnSet(configuration.ConfigurationItems, "Crust", "Thick", true);
            optionsSetter.SetOrUnSet(configuration.ConfigurationItems, "Toppings", "Extra Cheese", true);
            optionsSetter.SetOrUnSet(configuration.ConfigurationItems, "Toppings", "Pepperoni", true);

            //Make sure the configuration is correct
            var checker = new ConfigurationRulesChecker();
            List<string> errors;
            checker.Check(configuration, out errors);

            if (errors.Any())
            {
                return;
            }

            //Export the results to JSON
            var exporter = new ConfigurationExporter();
            var output = exporter.ExportToJson(configuration);
        }

    }
}
