using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configify.Data;

namespace Configify.Data.Fakes
{
    public class FakeConfigurationRepository : IConfigurationRepository
    {
        private readonly List<Configuration> configurations = new List<Configuration>();
        public FakeConfigurationRepository()
        {
            LoadInitialData();
        }

        public IEnumerable<Configuration> GetConfigurations()
        {
            return configurations;
        }

        public Configuration GetConfigurationById(Guid id)
        {
            return configurations.FirstOrDefault(c => c.Id == id);
        }

        private void LoadInitialData()
        {
            configurations.Add(PizzaConfigurationBuilder.BuildCompleteInstance());
        }

    }
}
