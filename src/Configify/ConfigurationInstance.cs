using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configify
{
    public class ConfigurationInstance
    {
        public Configuration Configuration { get; private set; }

        public IList<ConfigurationItemInstance>  ConfigurationItemInstances { get; private set; }

        public ConfigurationInstance(Configuration configuration)
        {
            ConfigurationItemInstances = new List<ConfigurationItemInstance>();
            this.Configuration = configuration;
        }

        public static ConfigurationInstance Build(Configuration configuration)
        {
            var instance = new ConfigurationInstance(configuration);

            foreach (var configurationItem in configuration.ConfigurationItems)
            {
                instance.ConfigurationItemInstances.Add(new ConfigurationItemInstance(configurationItem));
            }

            return instance;
        }

    }
}
