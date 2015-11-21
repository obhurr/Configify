using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configify
{
    public class ConfigurationInstanceItemOptionsSetter
    {
        public void Add(ConfigurationInstance instance, Option option)
        {
            var item = instance.ConfigurationItemInstances.FirstOrDefault(
                i => i.ConfigurationItem.Name.Equals(option.Name, StringComparison.OrdinalIgnoreCase));

            if (item == null) return;

            item.Options.Add(option);
        }

        public void Remove(ConfigurationInstance instance, Option option)
        {
            var item = instance.ConfigurationItemInstances.FirstOrDefault(
                i => i.ConfigurationItem.Name.Equals(option.Name, StringComparison.OrdinalIgnoreCase));

            if (item == null) return;

            var opt = item.Options.FirstOrDefault(o => o.Value.Equals(option.Value, StringComparison.OrdinalIgnoreCase));

            if(opt == null) return;

            item.Options.Remove(opt);
        }
    }
}
