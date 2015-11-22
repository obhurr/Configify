using System.Collections.Generic;

namespace Configify
{
    public class ExecutedConfigurationItem
    {
        public string Name { get; set; }

        public IList<ExecutedConfigurationItemOption> ConfigurationItemOptions { get; private set; }

        public ExecutedConfigurationItem()
        {
            ConfigurationItemOptions = new List<ExecutedConfigurationItemOption>();
        }
    }
}