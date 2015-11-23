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
        /// Optional field that can represent an item number/part number from a back end inventory system
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// Optional field that represents the price for the item
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The sequence of the item in the collection
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// Optional instructions for the end user that help him understand what he needs to do in order to configure the item
        /// </summary>
        public string EndUserInstructions { get; set; }

        public IList<ConfigurationItemOption> ConfigurationItemOptions { get; private set; }

        public IList<IConfigurationRule> ConfigurationRules { get; private set; }

        public ConfigurationItem()
        {
            ConfigurationItemOptions = new List<ConfigurationItemOption>();
            ConfigurationRules = new List<IConfigurationRule>();
        }

    }
}
