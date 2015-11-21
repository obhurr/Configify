using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configify
{
    public class Option
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public Option()
        {
            
        }

        public Option(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

    }
}
