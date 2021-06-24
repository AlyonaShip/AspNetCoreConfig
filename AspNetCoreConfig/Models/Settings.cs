using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreConfig.Models
{
    public class Settings
    {
        public EnvironmentSettings EnvironmentSettings { get; set; }
    }

    public class EnvironmentSettings
    {
        public string Name { get; set; }
    }
}
