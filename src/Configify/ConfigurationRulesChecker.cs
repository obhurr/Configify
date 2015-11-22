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
                foreach (var configurationRule in configurationItem.ConfigurationRules)
                {
                    if (configurationRule is MaxSelectedOptionsRule)
                    {
                        string error;
                        MaxSelectedOptionsRuleCheck(configurationItem, configurationRule as MaxSelectedOptionsRule, out error);
                        if (!string.IsNullOrEmpty(error))
                        {
                            errors.Add(error);                            
                        }
                    }

                    if (configurationRule is MinSelectedOptionsRule)
                    {
                        string error;
                        MinSelectedOptionsRuleCheck(configurationItem, configurationRule as MinSelectedOptionsRule, out error);
                        if (!string.IsNullOrEmpty(error))
                        {
                            errors.Add(error);
                        }
                    }
                }
            }
        }

        public void MinSelectedOptionsRuleCheck(
            ConfigurationItem configurationItem, MinSelectedOptionsRule rule, out string error)
        {
            error = string.Empty;
            var selectedCount = configurationItem.ConfigurationItemOptions.Count(o => o.IsSelected);

            if (selectedCount < rule.Count)
            {
                error = $"{configurationItem.Name} can have no more than {rule.Count} option(s)";
            }
        }

        public void MaxSelectedOptionsRuleCheck(
            ConfigurationItem configurationItem, MaxSelectedOptionsRule rule, out string error)
        {
            error = string.Empty;
            var selectedCount = configurationItem.ConfigurationItemOptions.Count(o => o.IsSelected);

            if (selectedCount > rule.Count)
            {
                error = $"{configurationItem.Name} requires at least {rule.Count} option(s)";
            }
        }

    }
}
