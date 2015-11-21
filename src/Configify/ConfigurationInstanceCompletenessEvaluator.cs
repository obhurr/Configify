using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configify
{
    /// <summary>
    /// Responsible for evaluating a configuration instance to ensure it is complete
    /// </summary>
    public class ConfigurationInstanceCompletenessEvaluator
    {
        public void Evaluate(ConfigurationInstance instance, out List<string> errors )
        {
            errors = new List<string>();

            foreach (var configurationItem in instance.Configuration.ConfigurationItems)
            {
                var itemInstance =
                    instance.ConfigurationItemInstances.FirstOrDefault(
                        i => i.ConfigurationItem.Name.Equals(configurationItem.Name, StringComparison.OrdinalIgnoreCase));

                if (itemInstance == null)
                {
                    errors.Add($"[SYS ERROR] Missing configuration instance item {configurationItem.Name}");
                    continue;
                }

                var optionsCount = itemInstance.Options.Count();

                if (optionsCount < configurationItem.OptionsMinCount)
                {
                    errors.Add($"{configurationItem.Name} requires at least {configurationItem.OptionsMinCount} option(s)");
                }

                if (optionsCount > configurationItem.OptionsMaxCount)
                {
                    errors.Add($"{configurationItem.Name} can have no more than {configurationItem.OptionsMaxCount} option(s)");
                }
            }
        }
    }
}
