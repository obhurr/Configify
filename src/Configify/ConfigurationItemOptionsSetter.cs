using System;
using System.Collections.Generic;
using System.Linq;

namespace Configify
{
    public class ConfigurationItemOptionsSetter
    {
        public void SetOrUnSet(IList<ConfigurationItem> configurationItems, string configItemName, string optionName,
            bool set)
        {
            var configurationItem =
                configurationItems.FirstOrDefault(
                    ci => ci.Name.Equals(configItemName, StringComparison.OrdinalIgnoreCase));

            if (configurationItem == null)
                return;

            var option =
                configurationItem.ConfigurationItemOptions.FirstOrDefault(
                    o => o.Name.Equals(optionName, StringComparison.OrdinalIgnoreCase));

            if (option == null)
                return;

            option.IsSelected = set;
        }
    }
}