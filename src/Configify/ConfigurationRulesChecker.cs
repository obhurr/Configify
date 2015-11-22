using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configify
{
    public class ConfigurationRulesChecker
    {
        public void Check(Configuration configuration, out List<string> errors)
        {
            errors = new List<string>();

            foreach (var configurationItem in configuration.ConfigurationItems)
            {
                var optionsCount = configurationItem.ConfigurationItemOptions.Count(o=>o.IsSelected);

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
