# Configify
A lightweight product configurator for .NET

Configify is a framework to allow simple products to be configured. 

#How to use - Pizza example
A pizza has a size, a crust, and toppings. The size can be either small, medium, or large and only 1 choice is allowed. Likewise the crust can be either thick, thin, or cheese stuffed and only 1 choice is allowed. The toppings are a bit different. Multiple toppings can be added. The following code defines a Pizza configuration with all available sub items and their options and rules.

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

Now that the pizza configuration has been defined, we can execute it and supply our own options, just as if we were a customer ordering a pizza. The helper _ConfigurationItemOptionsSetter_ class is used to set option values.

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
