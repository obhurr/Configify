using System;
using System.Collections.Generic;
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

    }
}
