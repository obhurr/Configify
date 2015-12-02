using System;
using System.Collections.Generic;
using System.Linq;

namespace Configify.Data.Fakes
{
    public class PizzaConfigurationBuilder
    {

        public Configuration Build()
        {
            var pizza = new Configuration
            {
                Name = "Pizza",
                Description = "Build your own Pizza",
                Id = Guid.Parse("C04B1949-75F1-4CB4-95D5-FE6B091EEA8E")
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
                EndUserInstructions = "Choose your Size",
                Id = Guid.Parse("B7720D93-F578-4704-979E-F1C7D95B49E6")
            };

            configurationItem.ConfigurationRules.Add(new MaxSelectedOptionsRule {Count = 1});
            configurationItem.ConfigurationRules.Add(new MinSelectedOptionsRule {Count = 1});

            configurationItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Small",
                Description = "4 slices, feeds 1 person",
                Sequence = 1,
                Id = Guid.Parse("F2117C46-AAE8-42A9-989C-4F4CCDCA980C")
            });

            configurationItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Medium",
                Description = "8 slices, feeds 2 people",
                Sequence = 2,
                Id = Guid.Parse("06FE851B-BF45-4F5D-8B53-D468BF8125B0")
            });

            configurationItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Large",
                Description = "16 slices, feeds 3 or 4 people",
                Sequence = 3,
                Id = Guid.Parse("3DDA7F59-7E69-4C03-B343-DAF8EDEB330C")
            });

            return configurationItem;
        }

        private ConfigurationItem BuildCrustItem(int sequence)
        {
            var configurationItem = new ConfigurationItem
            {
                Name = "Crust",
                Sequence = sequence,
                EndUserInstructions = "Choose your Crust",
                Id = Guid.Parse("3F9D2CD2-0EDA-4DE7-9951-E7C457BA3F09")
            };

            configurationItem.ConfigurationRules.Add(new MaxSelectedOptionsRule { Count = 1 });
            configurationItem.ConfigurationRules.Add(new MinSelectedOptionsRule { Count = 1 });

            configurationItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Thin",
                Sequence = 1,
                Id = Guid.Parse("BFCFCF8A-45F3-46A3-80FD-2B545715A5B0")

            });

            configurationItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Thick",
                Sequence = 2,
                Id = Guid.Parse("EC8E351E-8ED6-4308-AD21-F7267551808B")
            });

            configurationItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Cheese Filled",
                Sequence = 3,
                Id = Guid.Parse("482C3BBC-B6F5-4C36-88BD-216B9D5747DD")
            });

            return configurationItem;
        }

        private ConfigurationItem BuildToppingsItem(int sequence)
        {
            var configurationItem = new ConfigurationItem
            {
                Name = "Toppings",
                Sequence = sequence,
                EndUserInstructions = "Choose your toppings",
                Id = Guid.Parse("DFBD54D6-16DB-4363-8966-B4FDBE80E43F")
            };
            configurationItem.ConfigurationRules.Add(new MinSelectedOptionsRule { Count = 1 });

            configurationItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Extra Cheese",
                Sequence = 1,
                Id = Guid.Parse("31874172-560A-4B60-93EE-39999636969C")
            });

            configurationItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Pepperoni",
                Sequence = 2,
                Id = Guid.Parse("D5F35E1E-7D58-4607-83F5-6EAEF2CB411C")
            });

            configurationItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Sausage",
                Sequence = 3,
                Id = Guid.Parse("5FAEB33B-65FF-4295-AAD2-D16F6763C986")
            });

            configurationItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Canadian Bacon",
                Sequence = 4,
                Id = Guid.Parse("2C711877-488D-4DCF-A86F-F24F1D7FDC2F")
            });

            configurationItem.ConfigurationItemOptions.Add(new ConfigurationItemOption
            {
                Name = "Mushrooms",
                Sequence = 5,
                Id = Guid.Parse("78ED2669-DEDC-41C0-9B15-31DC9C4B749D")
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
