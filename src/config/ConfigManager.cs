using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Egen.Config
{
    public class ConfigurationManager
    {
        private readonly Dictionary<string, object>? _configData;

        public ConfigurationManager(string configFilePath)
        {
            string configJson = File.ReadAllText(configFilePath);
            _configData = JsonConvert.DeserializeObject<Dictionary<string, object>>(configJson);
        }

        public T? GetModuleConfig<T>(string moduleName) where T : IModuleConfig
        {
            if (_configData == null)
            {
                return default;
            }

            if (_configData.TryGetValue("modules", out var modules) && modules is Dictionary<string, object> modulesDict)
            {
                if (modulesDict.TryGetValue(moduleName, out var moduleData) && moduleData is JObject moduleConfig)
                {
                    return moduleConfig.ToObject<T>();
                }
            }

            return default;
        }
    }
}
