using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configify;
using NUnit;
using NUnit.Framework;

namespace Configify.Test
{
    [TestFixture]
    public class ConfigurationInstanceExporterTests
    {
        [Test]
        public void Does_Export()
        {
            var exporter = new ConfigurationInstanceExporter();
            var instance = PizzaConfigurationBuilder.BuildCompleteInstance();
            var output = exporter.ExportToJson(instance);
            Assert.IsNotNull(output);
        }
    }
}
