using System;
using System.Collections.Generic;
using System.Web.Http;
using Configify.Data;

namespace Configify.Web.Controllers.API
{
    public class ConfigsController : ApiController
    {
        private readonly IConfigurationRepository configurationRepository;

        public ConfigsController(IConfigurationRepository configurationRepository)
        {
            this.configurationRepository = configurationRepository;
        }

        // GET: api/Config
        public IEnumerable<Configuration> Get()
        {
            return configurationRepository.GetConfigurations();
        }

        // GET: api/Config/5
        public Configuration Get(Guid id)
        {
            return configurationRepository.GetConfigurationById(id);
        }

        // POST: api/Config
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Config/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Config/5
        public void Delete(int id)
        {
        }
    }
}
