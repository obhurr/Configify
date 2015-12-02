using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configify
{
    public class Configuration
    {
        public Guid Id { get; set; }
        
        /// <summary>
        /// The name of the configuration
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the configuration
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Optional field that can represent an item number/part number from a back end inventory system
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// Optional field that represents the price for the item
        /// </summary>
        public decimal Price { get; set; }

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
