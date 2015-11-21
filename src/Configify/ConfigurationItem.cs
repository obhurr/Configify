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

        /// <summary>
        /// The minimum number of options required in order to satisfy the item's requirement
        /// </summary>
        public decimal OptionsMinCount { get; set; }

        /// <summary>
        /// The maximum number of options required in order to satisfy the item's requirement
        /// </summary>
        public decimal OptionsMaxCount { get; set; }

        public ConfigurationItem()
        {
            ConfigurationItemOptions = new List<ConfigurationItemOption>();
        }

    }
}
