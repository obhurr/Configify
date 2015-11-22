using System.Collections.Generic;

namespace Configify
{
    public class ExecutedConfigurationItem
    {
        public string Name { get; set; }

        public IList<ExecutedConfigurationItemOption> ItemOptions { get; private set; }

        public ExecutedConfigurationItem()
        {
            ItemOptions = new List<ExecutedConfigurationItemOption>();
        }
    }
}