using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configify
{
    public class Configuration
    {
        /// <summary>
        /// The name of the configuration
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the configuration
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The collection of configuration items
        /// </summary>
        public IList<ConfigurationItem> ConfigurationItems { get; private set; }

        public Configuration()
        {
            ConfigurationItems = new List<ConfigurationItem>();
        }
    }
}
