using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configify
{
    /// <summary>
    /// Maker for configuration rules
    /// </summary>
    public interface IConfigurationRule
    {
        /// <summary>
        /// Necessary for serialization
        /// </summary>
        string Name { get; }
    }
}
