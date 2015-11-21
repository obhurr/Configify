using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configify
{
    public class ConfigurationItemInstance
    {
        public ConfigurationItem ConfigurationItem { get; private set; }

        public ConfigurationItemInstance(ConfigurationItem configurationItem)
        {
            Options = new List<Option>();
            this.ConfigurationItem = configurationItem;
        }

        public IList<Option> Options { get; private set; }
    }
}
