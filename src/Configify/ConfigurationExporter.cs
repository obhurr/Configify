using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Configify
{
    public class ConfigurationExporter
    {
        public string ExportToJson(Configuration configuration)
        {
            var export = Build(configuration);
            return JsonConvert.SerializeObject(export);
        }

        private ExecutedConfiguration Build(Configuration configuration)
        {
            var export = new ExecutedConfiguration
            {
                Name = configuration.Name,
                Description = configuration.Description
            };

            foreach (var item in configuration.ConfigurationItems)
            {
                var eci = new ExecutedConfigurationItem
                {
                    Name = item.Name
                };

                foreach (var configurationItemOption in item.ConfigurationItemOptions)
                {
                    eci.ItemOptions.Add(new ExecutedConfigurationItemOption
                    {
                        Name = configurationItemOption.Name,
                        Description = configurationItemOption.Description,
                        IsSelected = configurationItemOption.IsSelected
                    });
                }

                export.ConfigurationItems.Add(eci);
            }

            return export;
        }
    }
}
