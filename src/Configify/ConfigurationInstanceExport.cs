using System.Collections.Generic;

namespace Configify
{
    /// <summary>
    /// A lite class that represents a configuration instance
    /// </summary>
    public class ConfigurationInstanceExport
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IList<Option> Options { get; set; }

        public ConfigurationInstanceExport()
        {
            Options = new List<Option>();
        }

    }
}