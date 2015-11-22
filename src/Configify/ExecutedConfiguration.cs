using System.Collections.Generic;

namespace Configify
{
    /// <summary>
    /// A class that represents an executed configuration, useful for serialzied export
    /// </summary>
    public class ExecutedConfiguration
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IList<ExecutedConfigurationItem> ConfigurationItems { get; set; }

        public ExecutedConfiguration()
        {
            ConfigurationItems = new List<ExecutedConfigurationItem>();
        }
    }
}