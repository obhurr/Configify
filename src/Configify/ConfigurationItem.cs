using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configify
{
    public class ConfigurationItem
    {
        /// <summary>
        /// The name of the item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Instructions for the end user that help him understand what he needs to do in order to configure the item
        /// </summary>
        public string EndUserInstructions { get; set; }
        
        /// <summary>
        /// The sequence of the item in the collection
        /// </summary>
        public int Sequence { get; set; }

        public IList<ConfigurationItemOption> ConfigurationItemOptions { get; private set; }

        public IList<IConfigurationRule> ConfigurationRules { get; private set; }

        public ConfigurationItem()
        {
            ConfigurationItemOptions = new List<ConfigurationItemOption>();
            ConfigurationRules = new List<IConfigurationRule>();
        }

    }
}
