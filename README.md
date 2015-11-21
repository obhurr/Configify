# Configify
A lightweight product configurator for .NET

Configify is a framework to allow simple products to be configured. 

#How to use - Pizza example
A pizza has a size, a crust, and toppings. The size can be either small, medium, or large and only 1 choice is allowed. Likewise the crust can be either thick, thin, or cheese stuffed and only 1 choice is allowed. The toppings are a bit different. Multiple toppings can be added. The following code defines a Pizza configuration with all available sub items and their options and rules.

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

Now that the pizza configuration has been defined, we can run an instance and supply our own options, just as if we were a customer ordering a pizza. The static method _ConfigurationInstance.Build()_ generates the instance for us (always do this). The helper _ConfigurationInstanceItemOptionsSetter_ class is used to set option values.

    //Get the configuration for a pizza
    var configurationBuilder = new PizzaConfigurationBuilder();
    var configuration = configurationBuilder.Build();

    //Generate a new instance for this pizza order
    var instance = ConfigurationInstance.Build(configuration);

    //Set our options
    var optionsSetter = new ConfigurationInstanceItemOptionsSetter();
    optionsSetter.Add(instance, new Option("Size", "Large"));
    optionsSetter.Add(instance, new Option("Crust", "Thick"));
    optionsSetter.Add(instance, new Option("Toppings", "Extra Cheese"));
    optionsSetter.Add(instance, new Option("Toppings", "Pepperoni"));

    //Make sure the configuration is complete
    var evaluator = new ConfigurationInstanceCompletenessEvaluator();
    List<string> errors;
    evaluator.Evaluate(instance, out errors);

    if(errors.Any())
    {
        return;
    }

    //Export to results to JSON
    var exporter = new ConfigurationInstanceExporter();
    var output = exporter.ExportToJson(instance);
