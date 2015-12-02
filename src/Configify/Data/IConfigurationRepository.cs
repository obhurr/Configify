using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Configify.Data
{
    public interface IConfigurationRepository
    {
        IEnumerable<Configuration> GetConfigurations();
        Configuration GetConfigurationById(Guid id);
    }
}
