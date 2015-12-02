using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configify;
using Configify.Data.Fakes;
using NUnit;
using NUnit.Framework;

namespace Configify.Test
{
    [TestFixture]
    public class ConfigurationExporterTests
    {
        [Test]
        public void Does_Export()
        {
            var exporter = new ConfigurationExporter();
            var configuration = PizzaConfigurationBuilder.BuildCompleteInstance();
            var output = exporter.ExportToJson(configuration);
            Assert.IsNotNull(output);
        }
    }
}
