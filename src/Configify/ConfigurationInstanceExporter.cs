using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Configify
{
    public class ConfigurationInstanceExporter
    {
        public string ExportToJson(ConfigurationInstance instance)
        {
            var export = new ConfigurationInstanceExport
            {
                Name = instance.Configuration.Name,
                Description = instance.Configuration.Description
            };

            foreach (var option in instance.ConfigurationItemInstances.SelectMany(
                configurationItemInstance => configurationItemInstance.Options))
            {
                export.Options.Add(option);
            }

            return JsonConvert.SerializeObject(export);
        }
    }
}
