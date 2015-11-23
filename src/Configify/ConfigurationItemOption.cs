using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Configify
{
    public class ConfigurationItemOption
    {

        /// <summary>
        /// The name of the option
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the option
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The sequence of the option in the collection
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// Optional field that can represent an item number/part number from a back end inventory system
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// Optional field that represents the price for the option
        /// </summary>
        public decimal Price { get; set; }

        public bool IsSelected { get; set; }

    }
}
